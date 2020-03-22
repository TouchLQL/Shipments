//全局变量
var table, myGrid, ised = "";

$(document).ready(function () {
    GetMenuButtonList('btnOp');
    //#region datatable初始化及值绑定
    var scrollY = document.body.clientHeight - 53 - 36 - 38 - 32 - 20 - 5 - 4;
    //适应窗口大小变化
    $(window).resize(function () {
        var newScrollY = document.body.clientHeight - 53 - 36 - 38 - 32 - 20 - 5 - 4;
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
        search: 'txtSearch',
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
        order: [[0, 'asc']],
        data: {}
    }
    loadTableData(myGrid);
    //#endregion


    //日期框初始化
    $('#date_st,#date_ed,#date_delivery').datetimepicker({
        format: 'YYYY-MM-DD'
    });

    //查询
    $('#btnInquire').click(function () {
        loadTableData();
    });

    //双击选图标
    $('.modal-body .list-icon em').on('dblclick', function (e) {
        var icon = $(this).attr('class');
        $('#btnicon').val(icon);
        $('#iconModal').modal('hide');
    });

    //保存按钮-点击
    $('#btnSave').on('click', function () {
        if ($('form').parsley().validate()) {
            $.ajax({
                type: "post",
                contentType: "application/json;utf-8",
                url: "/Order/SaveOrder?t=" + new Date().getTime(),
                data: "{json:'" + $.toJSON(getOrderInfo()) + "'}",
                success: function (result) {
                    result = eval('(' + result + ')');
                    $.notify({
                        message: '<i class="fa fa-check"></i> ' + result.Message,
                        status: "success",
                        pos: "bottom-right"
                    });
                    if (result.IsSucceed) {
                        $('#btnCustomerModal').modal('hide');
                        loadTableData(myGrid);
                    }
                    else {
                        if (result.Entity != "" && result.Entity != null)
                            window.parent.location.href = result.Entity;
                    }
                }
            });
        }
    });
});

//新增
var Btn_Add = function () {
    $('#id').val('-1');
    $('#name').val('');
    $('#date_delivery_value').val('');
    $('#order_mark').val('');
    $('#orderId').val('-1');
    $('#orderNumber').val('-1');
    $('#orderAddModal').modal('show');
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
    $('#title').text("编辑订单");
    $('#customerId').val(seletedItem.customer_id);
    $('#date_delivery_value').val(seletedItem.delivery_time);
    $('#orderNumber').val(seletedItem.number);
    $('#orderId').val(seletedItem.id);
    $('#order_mark').val(seletedItem.mark);
    $('#orderAddModal').modal('show');
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
    bconfirm("确定删除？", btnDelete);
}
//删除方法
function btnDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/Order/DeleteOrder?id=" + seletedItem.id + "&t=" + new Date().getTime(),
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

//获取按钮信息
function getOrderInfo() {
    var btn = new Object();
    btn.id = $('#id').val();
    btn.name = $('#name').val();
    btn.address = $('#address').val();
    btn.person = $('#person').val();
    btn.tel = $('#tel').val();
    btn.mark = $('#mark').val();
    return btn;
}

//刷新datatable
function loadTableData(myGrid) {
    $.ajax({
        url: "/Order/GetAllOrder?t=" + new Date().getTime(),
        async: false,
        success: function (result) {
            result = eval('(' + result + ')');
            if (result.IsSucceed) {
                myGrid.data = eval(result.Entity);
                table = DataBind(myGrid);
            }
            else {
                $.notify({
                    message: '<i class="fa fa-check"></i> ' + result.Message,
                    status: "success",
                    pos: "bottom-right"
                });
                if (result.Entity != "" && result.Entity != null)
                    window.parent.location.href = result.Entity;
            }
        }
    });
}

