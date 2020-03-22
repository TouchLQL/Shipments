var id;
$(function () {
    $('#btncode').selectpicker({
        'selectedText': 'cat',
        'noneSelectedText': 'MenuButton'
    });
    //双击选图标
    $('.modal-body .list-icon em').on('dblclick', function (e) {
        var icon = $(this).attr('class');
        $('#icon').val(icon);
        $('#iconModal').modal('hide');
    });

    $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'PackUp');
    $('.tree li.parent_li > span').on('dblclick', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            children.hide('fast');
            $(this).attr('title', 'Unfold');
            //$(this).attr('title', 'Unfold').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
        } else {
            children.show('fast');
            $(this).attr('title', 'PackUp');
            //$(this).attr('title', 'PackUp').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
        }
        e.stopPropagation();
    });

    //全部Unfold
    $('#allunfolded').on('click', function (e) {
        var children = $('li.parent_li').find(' > ul > li');
        if (!children.is(":visible")) {
            children.show('fast');
            $('li.parent_li span').attr('title', 'PackUp');
        }
        e.stopPropagation();
    });

    //全部折叠
    $('#allfolded').on('click', function (e) {
        var children = $('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            children.hide('fast');
            $('li.parent_li span').attr('title', 'Unfold');
        }
        e.stopPropagation();
    });

    //树形结构的点击事件
    $('.tree li > span').on('click', function (e) {
        $('.tree li > span').removeClass("tc_color");
        $(this).addClass("tc_color");
        id = $(this).attr('id');
        setfunction($(this).attr('id'));
    });

    //删除事件
    function functiondel() {
        $.ajax({
            type: "post",
            contentType: "application/json;utf-8",
            url: "/System/DelFunction?id=" + id + "&t=" + new Date().getTime(),
            data: "",
            success: function (result) {
                result = eval('(' + result + ')');
                $.notify({
                    message: '<i class="fa fa-check"></i> ' + result.Message,
                    status: result.success ? "success" : 'danger',
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
    }


    //删除按钮 --点击
    $('#Btn_Delete').on('click', function () {
        if (id == "" || id == undefined) {
            $.notify({
                message: '<i class="fa fa-bell-o"></i> Choose one data please！',
                status: "info",
                group: null,
                pos: "bottom-right"
            });
            return;
        }
        bconfirm("Delete？", functiondel);
    })

    //重置按钮-点击
    $('#btnReset').on('click', function () {
        formReset();
    });
    //保存按钮-点击
    $('#btnSave').on('click', function () {
        if ($('form').parsley().validate()) {
            $.ajax({
                type: "post",
                contentType: "application/json;utf-8",
                //dataType: "json",
                url: "/System/FunctionSave?t=" + new Date().getTime(),
                data: "{json:'" + $.toJSON(getFunction()) + "'}",
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
        }
    });

    //获取菜单信息，并赋值
    function setfunction(id) {
        $.ajax({
            type: "post",
            url: "/System/OneFunction?t=" + new Date().getTime() + "&id=" + id,
            success: function (result) {//返回值
                result = eval('(' + result + ')');
                if (result.IsSucceed) {//成功
                    var func = result.Entity;
                    $('#btncode').selectpicker('val', result.Extend);
                    $('#did').val(func[0].id);
                    $('#pmenucode').val(func[0].pmenucode);
                    $('#menuname').val(func[0].menuname);
                    $('#linkaddress').val(func[0].linkaddress);
                    $('#icon').val(func[0].menuicon);
                    $('#menusort').val(func[0].menusort);
                }
                else {
                    $.notify({
                        message: '<i class="fa fa-exclamation"></i> ' + result.Message,
                        status: "danger",
                        pos: "bottom-right"
                    });
                    if (result.Entity != "" && result.Entity != null) {
                        window.parent.location.href = result.Entity;
                    }
                }
            }
        });
    }
    //获取菜单信息
    function getFunction() {
        var func = new Object();

        func.did = $('#did').val();
        func.pmenucode = $('#pmenucode').val();
        func.menuname = $('#menuname').val();
        func.linkaddress = $('#linkaddress').val();
        func.menuicon = $('#icon').val();
        func.menusort = $('#menusort').val();
        func.btncode = $('#btncode').val();
        //func.comment = $('#comment').val();

        return func;
    }
    //重置表单
    function formReset() {
        $('#did').val('-1');
        $('#pmenucode').val('-1');
        $('#menuname').val('');
        $('#linkaddress').val('');
        $('#icon').val('');
        $('#menusort').val('');
        //$('#comment').val('');
    }
    $("#Btn_Add").on('click', function () {
        formReset();
    });
});