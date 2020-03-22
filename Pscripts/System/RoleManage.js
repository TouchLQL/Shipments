var btn_save_bl = false;
$(function () {
    var btn_array = new Array("Btn_Add", "Btn_Edit", "Btn_Delete", "Btn_Save");
    $.ajax({
        type: "post",
        url: "/System/GetRoleMenuButton?t=" + new Date().getTime() + "&menucode=" + window.location.search.replace("?menucode_str=", "") + "&ctype=1",
        async: false, success: function (result) {
            result = eval('(' + result + ')'); if (result.IsSucceed) {
                if (result.Entity.length > 0) {
                    for (var i = 0; i < btn_array.length; i++) {
                        if (btn_array[i] == "Btn_Save") {
                            if (result.Entity.indexOf(btn_array[i]) >= 0)
                                btn_save_bl = true;
                        }
                        if (result.Entity.indexOf(btn_array[i]) >= 0)
                            $('#' + btn_array[i]).show();
                        else
                            $('#' + btn_array[i]).hide();
                    }
                }
                else {
                    for (var i = 0; i < btn_array.length; i++) {
                        $('#' + btn_array[i]).hide();
                    }
                }
            } else { if (result.Entity != "" && result.Entity != null) window.parent.location.href = result.Entity; }
        }
    });
    //角色树节点点击
    $('#role_tree li > span').on('click', function (e) {
        var id_val = $(this).attr('id').split('_')[1];
        if (id_val != "-1" && id_val != undefined) {
            $('#role_tree li > span').removeClass("tc_color");
            $(this).addClass("tc_color");
            $('#tree_id').val(id_val);
            setfunction(id_val);
        }
    });

    //角色新增按钮 - 点击
    $('#Btn_Add').on('click', function () {
        $('#tree_id').val('')
        InitVal();
        $('#roleAddModal').modal('show');
    });

    //编辑-弹出框-赋值
    $('#Btn_Edit').click(function () {
        InitVal();
        if ($('#tree_id').val() == "") {
            $.notify({
                message: '<i class="fa fa-bell-o"></i> Choose one data please！',
                status: "info",
                group: null,
                pos: "bottom-right"
            });
            return;
        }
        $.ajax({
            type: "post",
            url: "/System/GetRoleInfo?t=" + new Date().getTime() + "&id=" + $('#tree_id').val(),
            success: function (result) {//返回值
                result = eval('(' + result + ')');
                if (result.IsSucceed) {
                    var func = result.Entity;
                    $('#id').val(func[0].rolecode);
                    $('#rolename').val(func[0].rolename);
                    $('#rolesort').val(func[0].rolesort);
                    $('#remark').val(func[0].remark);
                    $('#roleAddModal').modal('show');
                }
                else {
                    $.notify({
                        message: '<i class="fa fa-exclamation"></i> ' + result.Message,
                        status: "danger",
                        pos: "bottom-right"
                    });
                    if (result.Entity != '' && result.Entity != null)
                        window.parent.location.href = result.Entity;
                }
            }
        });
    });

    //保存按钮 - 点击
    $('#btnSave').on('click', function () {
        if ($('form').parsley().validate()) {
            $.ajax({
                type: "post",
                contentType: "application/json;utf-8",
                url: "/System/RoleSave?t=" + new Date().getTime(),
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

    //删除按钮 --点击
    $('#Btn_Delete').on('click', function () {
        if ($('#tree_id').val() == "") {
            $.notify({
                message: '<i class="fa fa-bell-o"></i> Choose one data please！',
                status: "info",
                group: null,
                pos: "bottom-right"
            });
            return;
        }
        bconfirm("Delete？", roledel);

    })

    //删除事件
    function roledel() {
        $.ajax({
            type: "post",
            contentType: "application/json;utf-8",
            url: "/System/DelRoleManage?id=" + $('#tree_id').val() + "&t=" + new Date().getTime(),
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

    //获取菜单信息
    function getFunction() {
        var func = new Object();
        func.id = $('#id').val();
        func.rolename = $('#rolename').val();
        func.rolesort = $('#rolesort').val();
        func.remark = $('#remark').val();
        return func;
    }

    //树节点 - 点击
    function setfunction(id_val) {
        $.ajax({
            type: "post",
            contentType: "application/json;utf-8",
            url: "/System/GetRoleMenu?id=" + id_val + "&t=" + new Date().getTime(),
            data: "",
            success: function (result) {
                result = eval('(' + result + ')');
                var mp_code = "";
                if (result.IsSucceed) {
                    var m_list = result.Entity;
                    var pt_html = "", check_str = "";
                    for (var i = 0; i < m_list.length; i++) {
                        var pcode = m_list[i].id;
                        pt_html += '<ul><li>';
                        if (m_list[i].check == "1")
                            check_str = " btn-success";
                        else
                            check_str = ""
                        if (btn_save_bl)
                            pt_html += '<span class="f' + check_str + '" id="f_' + pcode + '" vtype="P' + pcode + '" onclick="setclass(\'P' + pcode + '\', \'f_' + pcode + '\',\'\')"><i class="' + m_list[i].icon + '"></i> ' + m_list[i].name + '</span>';
                        else
                            pt_html += '<span class="f' + check_str + '" id="f_' + pcode + '" vtype="P' + pcode + '"><i class="' + m_list[i].icon + '"></i> ' + m_list[i].name + '</span>';
                        var cm_list = m_list[i].cmdata;
                        if (cm_list.length > 0) {
                            for (var j = 0; j < cm_list.length; j++) {
                                var cpcode = cm_list[j].id;
                                pt_html += '<ul><li>';
                                if (cm_list[j].check == "1")
                                    check_str = " btn-success"
                                else
                                    check_str = "";
                                mp_code += cpcode + '_' + pcode + ',';
                                if (btn_save_bl)
                                    pt_html += '<span class="ms' + check_str + '" id="m_' + cpcode + '" vtype="P' + pcode + '" onclick="setclass(\'P' + pcode + '\', \'m_' + cpcode + '\', \'' + cpcode + '_' + pcode + '\')"><i class="' + cm_list[j].icon + '"></i>' + cm_list[j].name + '</span>&nbsp;&nbsp;&nbsp;';
                                else
                                    pt_html += '<span class="ms' + check_str + '" id="m_' + cpcode + '" vtype="P' + pcode + '"><i class="' + cm_list[j].icon + '"></i>' + cm_list[j].name + '</span>&nbsp;&nbsp;&nbsp;';
                                var b_list = cm_list[j].btndata;
                                if (b_list.length > 0) {
                                    for (var b = 0; b < b_list.length; b++) {
                                        var bcode = b_list[b].id;
                                        if (b_list[b].check == "1")
                                            check_str = " btn-success"
                                        else
                                            check_str = "";
                                        if (btn_save_bl)
                                            pt_html += '<span class="b' + check_str + '" id="b_' + bcode + '" vtype="P' + pcode + '" vtitle="' + cpcode + '_' + pcode + '" onclick="setclass(\'P' + pcode + '\', \'b_' + bcode + '\', \'' + cpcode + '_' + pcode + '\')"><i class="' + b_list[b].icon + '"></i>' + b_list[b].name + '</span>&nbsp;';
                                        else
                                            pt_html += '<span class="b' + check_str + '" id="b_' + bcode + '" vtype="P' + pcode + '" vtitle="' + cpcode + '_' + pcode + '"><i class="' + b_list[b].icon + '"></i>' + b_list[b].name + '</span>&nbsp;';
                                    }
                                }
                                pt_html += '</li></ul>';
                            }
                        }
                        pt_html += "</li></ul>";
                    }
                    $('#power_tree').html(pt_html);
                    $('#mpcode').val(mp_code.substring(0, mp_code.length - 1));
                }
                else {
                    if (result.Entity != "" && result.Entity != null)
                        window.parent.location.href = result.Entity;
                    else {
                        $.notify({
                            message: '<i class="fa fa-check"></i> ' + result.Message,
                            status: result.success ? "success" : 'danger',
                            pos: "bottom-right"
                        });
                    }
                }
            }
        });
    }

    //权限保存
    $('#Btn_Save').on('click', function () {
        var mp_str = $('#mpcode').val();
        var mp_list = mp_str.split(',');
        var r_str = "",pcode_str="";
        for (var i = 0; i < mp_list.length; i++) {
            var menucode_val = "", btncode_val = "";
            var m_id = mp_list[i].split('_')[0];
            if (pcode_str == "") {
                pcode_str = mp_list[i].split('_')[1];
            } else {
                if (pcode_str != mp_list[i].split('_')[1]) {
                    pcode_str = mp_list[i].split('_')[1];
                }
            }
            if ($('#m_' + m_id)[0].className.indexOf('btn-success') >= 0) {
                menucode_val = m_id;
                var v_obj = $("[vtitle='" + mp_list[i] + "']");
                for (var j = 0; j < v_obj.length; j++) {
                    var s_obj = v_obj[j];
                    var class_str = s_obj.className;
                    if (class_str.indexOf('btn-success') >= 0)
                        btncode_val += s_obj.id.split('_')[1] + ',';
                }
                r_str += pcode_str + "@|";
                r_str += menucode_val + "@" + btncode_val.substring(0, btncode_val.length - 1) + "|";
            }
        }
        if (r_str != "" && $('#tree_id').val() != "") {
            $.ajax({
                type: "post",
                contentType: "application/json;utf-8",
                url: "/System/SaveRoleMenu?request_str=" + r_str.substring(0, r_str.length - 1) + "&rolecode=" + $('#tree_id').val() + "&t=" + new Date().getTime(),
                data: "",
                success: function (result) {
                    result = eval('(' + result + ')');
                    $.notify({
                        message: '<i class="fa fa-check"></i> ' + result.Message,
                        status: result.IsSucceed ? "success" : 'danger',
                        pos: "bottom-right"
                    });
                    if (!result.IsSucceed) {
                        if (result.Entity != "" && result.Entity != null)
                            window.parent.location.href = result.Entity;
                    }
                }
            });
        }
    });
});

function InitVal() {
    $('#id').val('-1');
    $('#rolename').val('');
    $('#rolesort').val('');
    $('#remark').val('');
}

//菜单按钮选择操作
function setclass(vtype, id, title) {
    var t_val = id.substring(0, 1);
    var v_obj = $("[vtype='" + vtype + "']");
    var bl = false; var m_c = 0, s_c = 0, b_c = 0;
    if (t_val == "f") {
        if ($('#' + id)[0].className.indexOf('btn-success') >= 0)
            bl = true;
        for (var i = 0; i < v_obj.length; i++) {
            var s_obj = v_obj[i];
            var class_str = s_obj.className;
            if (bl)
                class_str = class_str.replace(' btn-success', '');
            else {
                if (class_str.indexOf('btn-success') < 0)
                    class_str += ' btn-success';
            }
            s_obj.className = class_str;
        }
    }
    else if (t_val == "m") {
        var v_class_str = $('#' + id)[0].className;
        if (v_class_str.indexOf('btn-success') >= 0) {
            v_class_str = v_class_str.replace(' btn-success', '');
            bl = true;
        }
        else
            v_class_str += ' btn-success';
        $('#' + id)[0].className = v_class_str;
        for (var i = 0; i < v_obj.length; i++) {
            var s_obj = v_obj[i];
            var obj_id = s_obj.id;
            var class_str = s_obj.className;
            if (obj_id.indexOf('m') >= 0) {
                m_c += 1;
                if (class_str.indexOf('btn-success') >= 0)
                    s_c += 1;
            }
            else if (obj_id.indexOf('b') >= 0) {
                if (s_obj.getAttribute('vtitle').indexOf(title) >= 0) {
                    if (bl)
                        class_str = class_str.replace(' btn-success', '');
                    else
                        class_str += ' btn-success';
                    s_obj.className = class_str;
                }
            }
        }
        var f_id = "f_" + vtype.substring(1, vtype.length);
        if (m_c == s_c) {
            v_class_str = $('#' + f_id)[0].className;
            if (v_class_str.indexOf('btn-success') < 0) {
                $('#' + f_id)[0].className = v_class_str + ' btn-success';
            }
        }
        else
            $('#' + f_id)[0].className = $('#' + f_id)[0].className.replace(' btn-success', '');
    }
    else {
        var m_id = "m_" + title.split('_')[0];
        for (var i = 0; i < v_obj.length; i++) {
            var s_obj = v_obj[i];
            var obj_id = s_obj.id;
            var class_str = s_obj.className;
            if (obj_id.indexOf('b') >= 0) {//找到按钮
                if (s_obj.getAttribute('vtitle').indexOf(title) >= 0) {
                    if (obj_id == id) {
                        if (class_str.indexOf('btn-success') >= 0)
                            class_str = class_str.replace(' btn-success', '');
                        else
                            class_str += ' btn-success';
                        if (class_str.indexOf('btn-success') >= 0)
                            b_c += 1;
                        s_obj.className = class_str;
                    }
                    else {
                        if (class_str.indexOf('btn-success') >= 0)
                            b_c += 1;
                    }
                }
            }
            else if (obj_id.indexOf('m') >= 0) {
                m_c += 1;
                if (class_str.indexOf('btn-success') >= 0)
                    s_c += 1;
            }
        }
        if (b_c > 0) {
            v_class_str = $('#' + m_id)[0].className;
            if (v_class_str.indexOf('btn-success') < 0) {
                $('#' + m_id)[0].className = v_class_str + ' btn-success';
                s_c += 1;
            }
        }
        var f_id = "f_" + vtype.substring(1, vtype.length);
        if (m_c == s_c) {
            v_class_str = $('#' + f_id)[0].className;
            if (v_class_str.indexOf('btn-success') < 0) {
                $('#' + f_id)[0].className = v_class_str + ' btn-success';
            }
        }
        else
            $('#' + f_id)[0].className = $('#' + f_id)[0].className.replace(' btn-success', '');
    }
}