ColorSoft.ViewModels = ColorSoft.ViewModels || {};

/***************** View Model *******************/

ColorSoft.ViewModels.MessagesViewModel = function () {
    var self = this;
    self.database = new ColorSoft.DataAccess.Database();

    self.messageToDelete = ko.observable(null);
    self.messages = ko.observableArray([]);
    self.deleteDialog = $("#deleteDialog");
    self.checkAllMessages = ko.observable(false);

    self.database.fetch(ColorSoft.Urls.ListMessages, null, function(data) {
            var mappedMessages = $.map(data, function(item) {
                return new ColorSoft.Models.Message(item);
            });
            self.messages(mappedMessages);
        },
        function() {
            alert("An error ocurred while fetching the messages.");
        });

    self.selectedMessages = ko.computed(function () {
        return _.filter(self.messages(), function (message) {
            return message.isSelected();
        });
    });

    self.checkAllMessages.subscribe(function (value) {
        _.each(self.messages(), function (message) {
            message.isSelected(value);
        });
    });

    self.sortBy = function (item, event) {
        var sortBy = $(event.currentTarget).data("sort");
        self.messages.sort(function (a, b) {
            var left = a[sortBy];
            var right = b[sortBy];
            return left === right ? 0 :
                (left < right ? -1 : 1);
        });
    };

    self.anyMessagesSelected = ko.computed(function () {
        return _.any(self.messages(), function (message) {
            return message.isSelected();
        });
    });

    self.deleteAllSelected = function () {
        self.database.removeAll(ColorSoft.Urls.DeleteMessages, self.selectedMessages(),
            function (result) {
                _.each(self.selectedMessages(), function (message) {
                    self.messages.remove(message);
                });
            },
            function () {
                alert("Error while deleting all selected messages.");
            });
    };

    self.confirmDeleteMessage = function (message) {
        self.messageToDelete(message);
        self.deleteDialog.modal("show");
    };

    self.deleteMessage = function () {
        var message = self.messageToDelete();
        self.closeDeleteConfirm();
        self.database.remove(ColorSoft.Urls.DeleteMessage, message, function (result) {
            self.messages.remove(message);
        },
        function () {
            alert("Error while deleting selected message.");
        });
    };

    self.closeDeleteConfirm = function () {
        self.messageToDelete(null);
        self.deleteDialog.modal("hide");
    };
};