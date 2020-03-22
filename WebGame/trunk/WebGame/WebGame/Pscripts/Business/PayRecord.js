//全局变量
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
        multiSelect: true,
        processing: true,
        serverSide: true,
        columns: [
            { data: "Row", title: "#", bSortable: false },
            { data: "mobile", title: "Mobile" },
            { data: "score", title: "Score" },
            { data: "gettime", title: "GetTime" },
            { data: "outtime", title: "OutTime" },
            { data: "ispick", title: "IsPick" },
            { data: "picktime", title: "PickTime" }
        ],
        columnDefs: [{
            render: function (data, type, row) {
                if (data==1)
                    return "yes";
                else
                    return "no";
            },
            targets: [5]
        }],
        order: [[0, 'desc']],
        data: {},
        ajax: function (data, callback, settings) {
            //封装请求参数
            var reUrl = '/Business/GetPayRecordList';
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
                    returnData.recordsFiltered = result.TotalCount; //后台不实现过滤功能，每次查询均视作全部结果
                    returnData.data = result.Entity; //返回的数据列表
                    //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                    //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                    callback(returnData);//将你的返回的data转为datatables能识别的数据格式作为参数返回ajax的callback回调中。
                }
            });
        }
    }

    table = DataBind(myGrid);
    //#endregion

    //日期框初始化
    $('#datetimepicker_st,#datetimepicker_ed').datetimepicker({
        format: 'YYYY-MM-DD'
    });

    //查询
    $('#btnInquire').click(function () {
        loadTableData();
    });
});

function PriseList(_gameScore, recordid) {
    $.ajax({
        url: "/Business/GetPrizesListByScore",
        data: { "score": parseInt(_gameScore) },
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data != "no prise") {
                $('#prizesModal').modal('show');
                var modelId = document.getElementById("myPrizesModal");
                modelId.innerHTML = "";
                for (var i = 0; i < data.length; i++) {
                    modelId.innerHTML += "<div id='" + data[i].id + "' onclick='GetPrise(" + data[i].id + "," + recordid + ")'><img src='" + data[i].imgpath + "'>";
                    modelId.innerHTML += "<div>" + data[i].prizesname +"</div></div>";
                }
                $('#prizesModal').modal('show');
            }
            else
            {
                layer.open({
                    content: 'Tidak ada hadiah yang tersedia！'
                });
            }
        }
    });
}
//领奖方法
function GetPrise(priseId, recordid) {
    layer.open({
        content: 'OK nampi?'
            , btn: ['Yes', 'No']
            , yes: function (index) {
                layer.close(index);
                    $.ajax({
                        url: "/Business/GetPrise",
                        data: { "priseId": priseId, "recordid": recordid },
                        type: "post",
                        dataType: "json",
                        success: function (data) {
                            layer.open({
                                content: data,
                                time: 2
                            });
                            $('#prizesModal').modal('hide');
                            loadTableData(myGrid);
                        }
                    });
            }
    });
}

//领奖按钮
var Btn_GetPrize = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i> Choose one data please！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    if (table.rows('.selected').data().length == 1)
    {
        var seletedItem = table.rows('.selected').data()[0];
        $('#prizeId').val(seletedItem.id);
        $('#imgpath').val('../../../' + seletedItem.imgpath);
        if (seletedItem.ispick == 0)
        {
            PriseList(seletedItem.score, seletedItem.id);
        }
        if(seletedItem.ispick ==1 )
        {
            $.notify({
                message: '<i class="fa fa-bell-o"></i> Telah menerima hadiah！',
                status: "info",
                group: null,
                pos: "bottom-right"
            });
            return;
        }
    }
    else
    {
        $.notify({
            message: '<i class="fa fa-bell-o"></i> Hanya bisa memilih data！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
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
    bconfirm("Delete？", LogDelete);
}
//删除方法
function LogDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/Business/PayRecordDelete?id=" + seletedItem.id + "&t=" + new Date().getTime(),
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

