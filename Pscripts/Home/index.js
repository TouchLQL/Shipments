$(function () {
    //一级菜单点击状态切换
    $('.menu-first').on('click', function () {
        $('ul.nav').find('li.menu-first.active').removeClass('active');
        $(this).addClass('active');
    });
    //功能菜单点击状态切换
    $('.menu-func').on('click', function () {
        $('ul.nav.sidebar-subnav').find('li.menu-func.active').removeClass('active');
        $(this).addClass('active');
    });
    //退出
    $('[data-toggle=logout]').click(function () {
        bconfirm('log out？', function () {
            window.location.href = '/home/logout';
        });
    });
    //密码修改
    $('#userPassword').click(function () {
        $('#userPasswordModal').modal('show');
    });
    //修改保存
    $('#btnPasswordSave').click(function () {
        if ($('form').parsley().validate()) {
            var oldpwd = $('#oldpassword').val();
            var newpwd = $('#newpassword').val();
            $.get("/System/UpdateUserPwd?pwd=" + newpwd + "&t=" + new Date().getTime(), function (result) {
                result = eval('(' + result + ')');
                $.notify({
                    message: '<i class="fa ' + (result.IsSucceed ? 'fa-check' : 'fa-exclamation') + '"></i> ' + result.Message,
                    status: result.IsSucceed ? 'success' : "danger",
                    pos: "bottom-right"
                });
                if (result.IsSucceed) {
                    setTimeout(function () {
                        $('#userPasswordModal').modal('hide');
                        window.location.href = '/home/login';
                    }, 2000);
                }
                else {
                    if (result.Entity != "" && result.Entity != null)
                        window.parent.location.href = result.Entity;
                }
            });
        }
    });
});