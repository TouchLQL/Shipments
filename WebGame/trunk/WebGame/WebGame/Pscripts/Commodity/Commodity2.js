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
            { data: "id", title: "ID" },
            { data: "name", title: "商品名" },
            { data: "number", title: "商品编号" },
            { data: "count", title: "库存" },
            { data: "type", title: "类型" },
            { data: "mark", title: "备注" }
        ],
        order: [[0, 'asc']],
        data: {}
    }
    loadTableData(myGrid);
    //#endregion

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
        }
    });
});



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

//刷新datatable
function loadTableData(myGrid) {
    $.ajax({
        url: "/Commodity/GetAllCommodity?t=" + new Date().getTime(),
        async: false,
        success: function (result) {     
            result = eval('(' + result + ')');
            if (result.IsSucceed) {
                console.log(result);
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
