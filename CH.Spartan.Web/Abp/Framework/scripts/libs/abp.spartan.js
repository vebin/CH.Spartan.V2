var abp = abp || {};
(function () {

    var dialog = null;
    if (!parent && !parent.layer && !layer) {
        return;
    }

    if (parent && parent.layer) {
        dialog = parent.layer;
    } else {
        dialog = layer;
    }

    /* notify NOTIFY **************************************************/

    var showNotification = function (type, message, title, options) {
        dialog.msg(message, { icon: type });
    };

    abp.notify.success = function (message, title, options) {
        showNotification(1, message, title, options);
    };

    abp.notify.info = function (message, title, options) {
        showNotification(0, message, title, options);
    };

    abp.notify.warn = function (message, title, options) {
        showNotification(3, message, title, options);
    };

    abp.notify.error = function (message, title, options) {
        showNotification(2, message, title, options);
    };


    /* MESSAGE **************************************************/

    var showMessage = function (type, message, title) {
        dialog.alert(message, { icon: type });
    };

    abp.message.info = function (message, title) {
        return showMessage(1, message, title);
    };

    abp.message.success = function (message, title) {
        return showMessage(0, message, title);
    };

    abp.message.warn = function (message, title) {
        return showMessage(3, message, title);
    };

    abp.message.error = function (message, title) {
        return showMessage(2, message, title);
    };

    abp.message.confirm = function (message, callback) {
        dialog.confirm(message, {
            btn: ["确定", "取消"],
            shade: false
        }, function (index) {
            if (callback) {
                callback(true);
            }
            dialog.close(index);
        }, function (index) {
            if (callback) {
                callback(false);
            }
            dialog.close(index);
        });
    };

    abp.message.prompt = function (message, callback) {
        dialog.prompt({
            title: message,
            formType: 1
        }, function (pass) {
            if (callback) {
                callback(pass);
            }
        });
    };

    /* BLOCK **************************************************/
    var block = 0;
    abp.ui.block = function (elm) {
        loablockding = dialog.load();
    };

    abp.ui.unblock = function (elm) {
        dialog.close(block);
    };

    /* BUSY **************************************************/
    var busy = 1;
    abp.ui.setBusy = function (elm, optionsOrPromise) {
        busy = dialog.load();
    };

    abp.ui.clearBusy = function (elm) {
        dialog.close(busy);
    };

    /* DIALOG **************************************************/
    abp.dialog.open = function (url, title, options) {
        options = options || {};
        var opts =
        {
            type: 2,
            title: title,
            shade: 0.1,
            maxmin: true,
            area: ["80%", "80%"],
            content: url
        };
        var args = $.extend({}, opts, options);
        dialog.open(args);
    };

    abp.dialog.close = function () {
        var index = dialog.getFrameIndex(window.name);
        dialog.close(index);
    };

})();