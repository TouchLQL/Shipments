﻿//全局变量
var table, myGrid;

$(document).ready(function () {
    GetMenuButtonList("btnOp");
    //#region datatable初始化及值绑定
    $.extend($.fn.dataTable.defaults, {
        dom: 'rt<"#dt-bottom.row"<"col-xs-2"l><"col-xs-7"p><"col-xs-3"i>>'
    });
    var scrollY = document.body.clientHeight - 56 - 53 - 38 - 32 - 13 - 4;
    //适应窗口大小变化
    $(window).resize(function () {
        var newScrollY = document.body.clientHeight - 56 - 53 - 38 - 32 - 13 - 4;
        $('.dataTables_scrollBody').css('height', newScrollY);
    });
    myGrid = {
        id: 'dt_log',
        isenable: false,//是否需要禁用启用按钮
        scrollY: scrollY,
        scrollX: true,
        paging: true,
        hasIndex: true,
        multiSelect: false,
        processing: true,
        serverSide: true,
        columns: [
            { data: null, title: "序号", bSortable: true },
            { data: "id", title: "ID" },
            { data: "name", title: "商品名" },
            { data: "number", title: "商品编号" },
            { data: "count", title: "库存" },
            { data: "type", title: "类型" },
            { data: "mark", title: "备注" }
        ],
        columnDefs: [],
        order: [[2, 'desc']],
        data: {},
        ajax: function (data, callback, settings) {
            //封装请求参数
            var reUrl = '/Commodity/GetAllCommodity';
            var order = data.columns[data.order[0].column].data + " " + data.order[0].dir;
            var pagesize = data.length;
            var pageno = (data.start / data.length) + 1;
            //查询条件
            var commodityType = $('#commodityType').val();
            var commodity_name = $('#commodity_name').val();
            var searchData = { pagesize: pagesize, pageno: pageno, order: order, commodityType: commodityType, commodity_name: commodity_name };
            console.log("dadddddddddddd");
            console.log(searchData);
            //ajax请求数据
            $.ajax({
                type: "GET",
                url: reUrl,
                cache: false,//禁用缓存
                data: searchData,//传入组装的参数
                dataType: "json",
                //headers: param,//请求头参数
                success: function (result, status, xhr) {
                    //封装返回数据
                    var returnData = {};
                    returnData.draw = data.draw; //这里直接自行返回了draw计数器,应该由后台返回
                    returnData.recordsTotal = result.TotalCount;
                    total_curr = result.TotalCurr;
                    returnData.recordsFiltered = result.TotalCount; //后台不实现过滤功能，每次查询均视作全部结果
                    returnData.data = result.Entity; //返回的数据列表
                    //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                    //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                    callback(returnData);//将你的返回的data转为datatables能识别的数据格式作为参数返回ajax的callback回调中。
                }
            });
        }
    }

    $('#dt_log').on('dblclick', 'tr', function () {
        var r_obj = $(this);
        r_obj.addClass('selected');
        var row_val = $('#dt_log').DataTable().row(r_obj).data();
        $('#c_title').text("ViewLog");
        $('#content').html(row_val.logcontent);
        $('#logManageModal').modal('show');
    });

    table = DataBind(myGrid);
    //#endregion

    //日期框初始化
    //$('#datetimepicker_st,#datetimepicker_ed').datetimepicker({
    //    format: 'YYYY-MM-DD'
    //});

    //查询
    $('#btnInquire').click(function () {
        loadTableData();
    });
    //保存按钮-点击
    $('#btnSave').on('click', function () {
        //if ($('form').parsley().validate()) {
            $.ajax({
                type: "post",
                contentType: "application/json;utf-8",
                url: "/Commodity/SaveCommodity?t=" + new Date().getTime(),
                data: "{json:'" + $.toJSON(getCommodityInfo()) + "'}",
                success: function (result) {
                    result = eval('(' + result + ')');
                    $.notify({
                        message: '<i class="fa fa-check"></i> ' + result.Message,
                        status: "success",
                        pos: "bottom-right"
                    });
                    if (result.IsSucceed) {
                        $('#btnComodityModal').modal('hide');
                        loadTableData(myGrid);
                    }
                    else {
                        if (result.Entity != "" && result.Entity != null)
                            window.parent.location.href = result.Entity;
                    }
                }
            });
        //}
    });
});

//刷新datatable
function loadTableData(myGrid) {
    table.ajax.reload();
}


//删除
var Btn_Delete = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i>请选择一条数据！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    bconfirm("确定删除？", btnDelete);
}
//删除方法
function btnDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/Commodity/DeleteCommodity?id=" + seletedItem.id + "&t=" + new Date().getTime(),
        data: "",
        success: function (result) {
            result = eval('(' + result + ')');
            $.notify({
                message: '<i class="fa fa-check"></i> ' + result.Message,
                status: result.success ? "success" : 'danger',
                pos: "bottom-right"
            });
            if (result.IsSucceed) {
                loadTableData(myGrid);
            }
            else {
                if (result.Entity != "" && result.Entity != null)
                    window.parent.location.href = result.Entity;
            }
        }
    });
}

//新增
var Btn_Add = function () {
    $('#id').val('-1');
    $('#name').val('');
    $('#type').val('');
    $('#count').val('');
    $('#unit').val('');
    $('#special_supply').val('');
    $('#price').val('');
    $('#mark').val('');
    $('#btnComodityModal').modal('show');
}

//编辑
var Btn_Edit = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i> Choose one data please！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    var seletedItem = table.rows('.selected').data()[0];
    $('#title').text("编辑商品");
    $('#id').val(seletedItem.id);
    $('#name').val(seletedItem.name);
    $('#type').val(seletedItem.type);
    $('#count').val(seletedItem.count);
    $('#unit').val(seletedItem.unit);
    $('#special_supply').val(seletedItem.special_supply);
    $('#price').val(seletedItem.price);
    $('#mark').val(seletedItem.mark);
    $('#btnComodityModal').modal('show');
}
//获取商品信息
function getCommodityInfo() {
    var btn = new Object();
    btn.id = $('#id').val();
    btn.name = $('#name').val();
    btn.type = $('#type').val();
    btn.count = $('#count').val();
    btn.unit = $('#unit').val();
    btn.special_supply = $('#special_supply').val();
    btn.price = $('#price').val();
    btn.mark = $('#mark').val();
    return btn;
}
