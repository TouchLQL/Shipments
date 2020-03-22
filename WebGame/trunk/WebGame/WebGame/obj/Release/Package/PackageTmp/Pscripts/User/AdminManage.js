//全局变量
var table, myGrid, ised = "";

$(document).ready(function () {

    //文件input加css及验证
    $('.group-span-filestyle,.input-group-btn').addClass('vertical-top');
    //$('.bootstrap-filestyle,.input-group input').attr('required', 'required').attr('data-parsley-error-message', '未选择图片...');
    //btns
    GetMenuButtonList('btnOp');
    //#region datatable初始化及值绑定
    var scrollY = document.body.clientHeight - 53 - 56 - 56 - 45 - 15 - 22;
    var pagesize = parseInt((scrollY - 20) / 37.8) >= 10 ? 10 : parseInt((scrollY - 20) / 37.8);
    myGrid = {
        id: 'dt_admin',
        isenable: false, //是否需要禁用启用按钮
        scrollY: scrollY,
        lengthMenu: [[pagesize, 25, 50, -1], [pagesize, 25, 50, "All"]],
        scrollX: true,
        paging: true,
        hasIndex: true,
        multiSelect: false,
        search: 'txtSearch',
        columns: [
                { data: null, title: "#" },
                { data: "usercode", title: "UserCode" },//"visible": false
                { data: "username", title: "UserName" },//"visible": false 
                { data: "rolename", title: "RoleName" },
                { data: "pname", title: "Name" },
                { data: "phone", title: "Phone" },
                { data: "remark", title: "Remark" },
                { data: "isenable", title: "IsEnable" }
        ],
        columnDefs: [
        {
            render: function (data, type, row) {
                return row.isenable == 1 ? '<i class="fa fa-check text-success"></i>' : '<i class="fa fa-minus-circle text-danger"></i>';
            },
            targets: [7]
        }],
        order: [[0, 'asc']],
        data: {}
    }
    loadTableData(myGrid);
    //#endregion 

    //字母转大写
    $(":text").change(function (e) {
        $(this).val($(this).val().toUpperCase());
    });

    //保存按钮-点击
    $('#btnSave').on('click', function () {
        if ($('form').parsley().validate()) {
            var file = $('#filestyle-0');
            if (file[0].files && file[0].files[0]) {
                ImgToBase64(file[0]);
            } else {
                AjaxSave(getUserInfo());
            }
        }
    });

    //选择页面已有图片样式
    $('img').on('click', function () {
        $(':file').filestyle('clear');
        $('#imgmask').css("display", "block");
        $('#imgmask').css("left", ($(this).attr("imgindex") * 60) + 15 + $(this).attr("imgindex") * 3);
        $('img').removeClass("selected");
        $(this).addClass("selected");
        $("#avatar").val($(this).attr("imgindex"));
    });
    $('#imgmask').on('click', function () {
        $('#imgmask').css("display", "none");
        $("#avatar").val("-1");
    });
});


//新增
var Btn_Add = function () {
    $('#title').text("AddUser");
    $('#id').val('-1');
    $('#username').val('');
    //$('#rolecode').html('').selectpicker('refresh');
    $('#pname').val('');
    $('#phone').val('');
    $('#wechat').val('');
    $('#remark').val('');
    $('#avatar').val('-1');
    $(':file').filestyle('clear');
    $('#adminManageModal').modal('show');
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
    $('#title').text("UserEdit");
    $('#id').val(seletedItem.id);
    $('#username').val(seletedItem.username);
    $('#rolecode').selectpicker('val', seletedItem.rolecode);
    $('#pname').val(seletedItem.pname);
    $('#phone').val(seletedItem.phone);
    $('#wechat').val(seletedItem.wechat);
    $('#remark').val(seletedItem.remark);
    $('#avatar').val(seletedItem.avatar);

    $('#adminManageModal').modal('show');
}

//获取信息
function getUserInfo() {
    var user = new Object();
    user.id = $('#id').val();
    user.username = $('#username').val();
    user.rolecode = $('#rolecode').val();
    user.pname = $('#pname').val();
    user.phone = $('#phone').val();
    user.wechat = $('#wechat').val();
    user.remark = $('#remark').val();
    user.base64 = "-1";
    user.avatar = $('#avatar').val();
    return user;
}

//刷新datatable
function loadTableData(myGrid) {
    $.ajax({
        url: "/User/GetAllAdmins?t=" + new Date().getTime(),
        async: false,
        success: function (result) {
            result = eval('(' + result + ')');
            if (result.IsSucceed) {
                myGrid.data = eval(result.Entity);
                table = DataBind(myGrid);
            }
            else {
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
            message: '<i class="fa fa-exclamation"></i> Choose one data please！',
            status: "danger",
            pos: "bottom-right"
        });
        return;
    }
    else {
        ised = "1";
        var tips = 'IsEnable ' + seletedItem[0].pname + ' User？';
        bconfirm(tips, AdminEnableOrDisabled);
    }
}

//禁用
var Btn_Disabled = function () {
    var seletedItem = table.rows('.selected').data();
    if (seletedItem.length == 0) {
        $.notify({
            message: '<i class="fa fa-exclamation"></i> Choose one data please！',
            status: "danger",
            pos: "bottom-right"
        });
        return;
    }
    else {
        ised = "0";
        var tips = 'ISDisable ' + seletedItem[0].pname + ' User？';
        bconfirm(tips, AdminEnableOrDisabled);
    }
}

//用户禁用或启用
function AdminEnableOrDisabled() {
    var seletedItem = table.rows('.selected').data()[0];
    $.get("/User/AdminEnableOrDisabled?id=" + seletedItem.id + "&ised=" + ised + "&t=" + new Date().getTime(), function (result) {
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

//图片转成base64
function ImgToBase64(e) {
    var reader = new FileReader();
    reader.readAsDataURL(e.files[0]);
    reader.onload = function (e) {
        var user = getUserInfo();
        user.base64 = this.result;
        user.avatar = '-1';
        AjaxSave(user);
    }
}

function AjaxSave(obj) {
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/User/AdminManageSave?t=" + new Date().getTime(),
        data: "{json:'" + $.toJSON(obj) + "'}",
        success: function (result) {
            result = eval('(' + result + ')');
            $.notify({
                message: '<i class="fa ' + (result.IsSucceed ? 'fa-check' : 'fa-exclamation') + '"></i> ' + result.Message,
                status: result.IsSucceed ? 'success' : "danger",
                pos: "bottom-right"
            });
            if (result.IsSucceed) {
                $('#adminManageModal').modal('hide');
                loadTableData(myGrid);
            }
            else {
                if (result.Entity != "" && result.Entity != null)
                    window.parent.location.href = result.Entity;
            }
        }
    });
}