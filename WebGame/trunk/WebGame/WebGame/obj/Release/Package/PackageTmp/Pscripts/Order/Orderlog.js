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
        id: 'dt_logz',
        isenable: false,//是否需要禁用启用按钮
        scrollY: scrollY,
        scrollX: true,
        paging: true,
        hasIndex: true,
        multiSelect: true,
        processing: true,
        serverSide: true,
        columns: [
            { data: null, title: "序号", bSortable: true },
            { data: "number", title: "订单号", bSortable: true },
            { data: "customer_name", title: "商家名字" },
            { data: "customer_address", title: "商家地址" },
            { data: "customer_tel", title: "商家电话" },
            { data: "customer_person", title: "联系人" },
            { data: "create_time", title: "创建时间", bSortable: true },
            { data: "delivery_time", title: "发货时间", bSortable: true },
            { data: "status", title: "状态" },
            { data: "mark", title: "备注" }
        ],
        columnDefs: [{
            render: function (data, type, row) {
                if (data.length > 12)
                    return data.substring(0, 12) + "...";
                else
                    return data;
            },
            targets: [8]
        }],
        order: [[2, 'desc']],
        data: {},
        ajax: function (data, callback, settings) {
            //封装请求参数
            var reUrl = '/Order/GetAllOrder';
            var order = data.columns[data.order[0].column].data + " " + data.order[0].dir;
            var pagesize = data.length;
            var pageno = (data.start / data.length) + 1;
            //查询条件
            var s_customerId = $('#s_customerId').val();
            var datest = $('#date_st').val();
            var dateed = $('#date_ed').val();
            var searchData = { pagesize: pagesize, pageno: pageno, order: order, customerId: s_customerId, datest: datest, dateed: dateed };
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

    //$('#dt_log').on('dblclick', 'tr', function () {
    //    var r_obj = $(this);
    //    r_obj.addClass('selected');
    //    var row_val = $('#dt_log').DataTable().row(r_obj).data();
    //    $('#c_title').text("ViewLog");
    //    $('#content').html(row_val.logcontent);
    //    $('#logManageModal').modal('show');
    //});

    table = DataBind(myGrid);
    //#endregion

    //日期框初始化
    $('#date_st,#date_ed,#date_delivery').datetimepicker({
        format: 'YYYY-MM-DD'
    });

    //查询
    $('#btnInquire').click(function () {
        loadTableData();
    });
});

//刷新datatable
function loadTableData(myGrid) {
    table.ajax.reload();
}





