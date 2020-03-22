//全局变量
var table, myGrid;

$(document).ready(function () {

    $(document).on('ready', function () {
        $("#imgpath").fileinput({ showCaption: false });
    });
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
        id: 'dt_btn',
        isenable: false,//是否需要禁用启用按钮
        scrollY: scrollY,
        scrollX: true,
        paging: true,
        hasIndex: true,
        multiSelect: false,
        processing: true,
        serverSide: true,
        columns: [
            { data: "Row", title: "#", bSortable: false },
            { data: "id", title: "id" },
            { data: "prizesname", title: "PrizesName" },
            { data: "imgpath", title: "ProductImgage" },
            { data: "uptime", title: "Uptime" },
            { data: "score",title :"Score"}
        ],
        columnDefs: [{
            render: function (data, type, row) {
                return '<img src="../../../' + data + '" style="width:25%"/>';
            },
            targets: [3]
        }, {
            "targets": [1],
            "visible": false
        }],
        order: [[2, 'desc']],
        data: {},
        ajax: function (data, callback, settings) {
            //封装请求参数
            var reUrl = '/Business/GetPrizesList';
            var order = data.columns[data.order[0].column].data + " " + data.order[0].dir;
            var pagesize = data.length;
            var pageno = (data.start / data.length) + 1;
            //查询条件
            var datest = $('#date_st').val();
            var dateed = $('#date_ed').val();
            var searchData = { pagesize: pagesize, pageno: pageno, order: order, datest: datest, dateed: dateed };
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
                    returnData.recordsFiltered = result.TotalCount;
                    returnData.data = result.Entity;
                    callback(returnData);
                }
            });
        }
    }

    table = DataBind(myGrid);
    //#endregion

    //日期框初始化
    $('#datetimepicker_st').datetimepicker({
        format: 'YYYY-MM-DD'
    });

    $("#btnSave").click(function () {
        //模态框中添加图片 两种做法

        $("#mm").ajaxSubmit({
            url: "/Business/SavePrizes",  //访问这个方法用来得到图片名称
            type: "post",
            success: function (result) {
                result = eval('(' + result + ')');
                $.notify({
                    message: '<i class="fa ' + (result.IsSucceed ? 'fa-check' : 'fa-exclamation') + '"></i> ' + result.Message,
                    status: result.IsSucceed ? 'success' : "danger",
                    pos: "bottom-right"
                });
                if (result.IsSucceed) {
                    location.reload();
                }
                else {
                    if (result.Entity != "" && result.Entity != null)
                        window.parent.location.href = result.Entity;
                }
            }
        });
    });

});

var Btn_Add = function () {
    $('#id').val('-1');
    $('#prizesname').val('');
    $('#imgpath').val('');
    $('#btnAddModal').modal('show');
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
    $('#title').text("Prizes Edit");
    $('#id').val(seletedItem.id);
    $('#prizesname').val(seletedItem.prizesname);
    //$('#imgpath').val('../../../' + seletedItem.imgpath);
    $('#score').val(seletedItem.score);
    $('#btnAddModal').modal('show');
}
//刷新datatable
function loadTableData(myGrid) {
    table.ajax.reload();
}


//删除
var Btn_Delete = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i> Choose one data please！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    bconfirm("Delete？", ProductDelete);
}
//删除方法
function ProductDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/Business/PrizesDelete?id=" + seletedItem.id + "&t=" + new Date().getTime(),
        data: "",
        success: function (result) {
            result = eval('(' + result + ')');
            $.notify({
                message: '<i class="fa ' + (result.IsSucceed ? 'fa-check' : 'fa-exclamation') + '"></i> ' + result.Message,
                status: result.IsSucceed ? 'success' : "danger",
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

