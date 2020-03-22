//自定义alert：tip&confirm
var bconfirm = function (msg, callback, param) {
    bindElement(msg);
    $('#confirm-ok').click(function () {
        $('#confirmAlertModal').modal('hide');
        if (callback && typeof callback == "function")
            if (param != null && param != "")
                callback(param);
            else
                callback(true);
    });
}

var bindElement = function (msg) {
    $('#confirmAlertModal').remove();
    var iclass = 'icon-check';
    //confirm确认消息
    var confirmAlertHtml = '<div id="confirmAlertModal" tabindex="-1" role="dialog" aria-labelledby="alertModalLabel" aria-hidden="true" class="modal fade">' +
        '<div class="modal-dialog modal-sm"><div class="modal-content"><div class="modal-header">' +
        '<button type="button" data-dismiss="modal" aria-label="Close" class="close"><span aria-hidden="true">&times;</span></button>' +
        '<i class="' + iclass + '">&nbsp;Operate Confirm</i></div><div class="modal-body">' + msg + '</div><div class="modal-footer">' +
        '<button type="button" data-dismiss="modal" class="btn btn-default">Cancel</button><button id="confirm-ok" type="button" class="btn btn-primary">OK</button></div></div></div></div>';
    $('body').append(confirmAlertHtml);
    $('#confirmAlertModal').modal('show');
}

Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,
        //月份
        "d+": this.getDate(),
        //日
        "H+": this.getHours(),
        //小时
        "m+": this.getMinutes(),
        //分
        "s+": this.getSeconds(),
        //秒
        "q+": Math.floor((this.getMonth() + 3) / 3),
        //季度
        "S": this.getMilliseconds() //毫秒
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}