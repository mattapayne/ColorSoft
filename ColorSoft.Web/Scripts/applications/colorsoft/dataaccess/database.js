ColorSoft.DataAccess = ColorSoft.DataAccess || {};

ColorSoft.DataAccess.Database = function () {
};

ColorSoft.DataAccess.Database.prototype.doPost = function (url, obj, successCallback, failCallback) {
    var json = ko.toJSON(obj);

    var request = $.ajax({
        type: 'POST',
        url: url,
        data: json,
        contentType: 'application/json',
        dataType: 'json'
    });

    request.done(function (result) {
        if (successCallback) {
            successCallback(result);
        }
    });

    request.fail(function () {

        if (failCallback) {
            failCallback();
        }
    });
};

ColorSoft.DataAccess.Database.prototype.save = function (url, obj, successCallback, failCallback) {
    this.doPost(url, obj, successCallback, failCallback);
};

ColorSoft.DataAccess.Database.prototype.update = function (url, obj, successCallback, failCallback) {
    this.doPost(url, obj, successCallback, failCallback);
};

ColorSoft.DataAccess.Database.prototype.remove = function (url, obj, successCallback, failCallback) {
    this.doPost(url, obj, successCallback, failCallback);
};

ColorSoft.DataAccess.Database.prototype.removeAll = function (url, objs, successCallback, failCallback) {
    this.doPost(url, objs, successCallback, failCallback);
};

ColorSoft.DataAccess.Database.prototype.fetch = function (url, args, successCallback, failCallback) {
    var request = $.getJSON(url, args);
    request.done(function (result) {
        if (successCallback) {
            successCallback(result);
        }
    });
    request.fail(function () {
        if (failCallback) {
            failCallback();
        }
    });
}