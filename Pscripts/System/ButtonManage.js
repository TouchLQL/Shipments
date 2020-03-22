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
                { data: null, title: "#", bSortable: false },
                { data: "btncode", title: "BtnCode" },//"visible": false
                { data: "btnname", title: "BtnName" },
                { data: "btnclass", title: "BtnClass" },
                { data: "btnicon", title: "BtnIcon" },
                { data: "btnmethod", title: "BtnMethod" },
                { data: "isenable", title: "IsEnable" }
        ],
        columnDefs: [{
            render: function (data, type, row) {
                return '<i class="' + row.btnicon + '"></i>';
            },
            targets: [4]
        }, {
            render: function (data, type, row) {
                return row.isenable == 1 ? '<i class="fa fa-check text-success"></i>' : '<i class="fa fa-minus-circle text-danger"></i>';
            },
            targets: [6]
        }],
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
                url: "/System/BtnManageSave?t=" + new Date().getTime(),
                data: "{json:'" + $.toJSON(getBtnInfo()) + "'}",
                success: function (result) {
                    result = eval('(' + result + ')');
                    $.notify({
                        message: '<i class="fa fa-check"></i> ' + result.Message,
                        status: "success",
                        pos: "bottom-right"
                    });
                    if (result.IsSucceed) {
                        $('#btnAddModal').modal('hide');
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
    $('#btnname').val('');
    $('#btnmethod').val('');
    $('#btnclass').val('');
    $('#btnicon').val('');
    $('#btnsort').val('');
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
    $('#title').text("BtnEdit");
    $('#id').val(seletedItem.id);
    $('#btnname').val(seletedItem.btnname);
    $('#btnclass').val(seletedItem.btnclass);
    $('#btnmethod').val(seletedItem.btnmethod);
    $('#btnicon').val(seletedItem.btnicon);
    $('#btnsort').val(seletedItem.btnsort);
    $('#btnAddModal').modal('show');
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
    bconfirm("Delete？", btnDelete);
}
//删除方法
function btnDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/System/BtnManageDelete?id=" + seletedItem.id + "&t=" + new Date().getTime(),
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
function getBtnInfo() {
    var btn = new Object();
    btn.id = $('#id').val();
    btn.btnname = $('#btnname').val();
    btn.btnclass = $('#btnclass').val();
    btn.btnicon = $('#btnicon').val();
    btn.btnmethod = $('#btnmethod').val();
    btn.btnsort = $('#btnsort').val();
    return btn;
}

//刷新datatable
function loadTableData(myGrid) {
    $.ajax({
        url: "/System/GetAllButtons?t=" + new Date().getTime(),
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

//启用
var Btn_Enable = function () {
    var seletedItem = table.rows('.selected').data();
    if (seletedItem.length == 0) {
        $.notify({
            message: '<i class="fa fa-exclamation"></i> Choose one button please！',
            status: "danger",
            pos: "bottom-right"
        });
        return;
    }
    else {
        ised = "1";
        var tips = '是否启用 ' + seletedItem[0].btnname + ' Button？';
        bconfirm(tips, btnEnableOrDisabled);
    }
}

//禁用
var Btn_Disabled = function () {
    var seletedItem = table.rows('.selected').data();
    if (seletedItem.length == 0) {
        $.notify({
            message: '<i class="fa fa-exclamation"></i> Choose one button please！',
            status: "danger",
            pos: "bottom-right"
        });
        return;
    }
    else {
        ised = "0";
        var tips = 'IdDisabled ' + seletedItem[0].btnname + ' Button？';
        bconfirm(tips, btnEnableOrDisabled);
    }
}


//按钮禁用或启用
function btnEnableOrDisabled() {
    var seletedItem = table.rows('.selected').data()[0];
    $.get("/System/BtnEnableOrDisabled?id=" + seletedItem.id + "&ised=" + ised + "&t=" + new Date().getTime(), function (result) {
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
    });
}


