ColorSoft.ViewModels = ColorSoft.ViewModels || {};

/***************** View Model *******************/

ColorSoft.ViewModels.UsersViewModel = function () {
    var self = this;
    self.database = new ColorSoft.DataAccess.Database();

    self.userToDelete = ko.observable(null);
    self.users = ko.observableArray([]);
    self.deleteDialog = $("#deleteDialog");
    self.checkAllUsers = ko.observable(false);

    self.database.fetch(ColorSoft.Urls.ListUsers, null, function (data) {
        var mappedUsers = $.map(data, function (item) {
            return new ColorSoft.Models.User(item);
        });
        self.users(mappedUsers);
    },
        function () {
            alert("An error ocurred while fetching the users.");
        });

    self.checkAllUsers.subscribe(function (value) {
        _.each(self.users(), function (user) {
            user.isSelected(value);
        });
    });

    self.selectedUsers = ko.computed(function () {
        return _.filter(function (user) {
            return user.isSelected();
        });
    });

    self.anyUsersSelected = ko.computed(function () {
        return _.any(self.users(), function (user) {
            return user.isSelected();
        });
    });

    self.sortBy = function (item, event) {
        var sortBy = $(event.currentTarget).data("sort");
        self.users.sort(function (a, b) {
            var left = a[sortBy];
            var right = b[sortBy];
            return left === right ? 0 :
                (left < right ? -1 : 1);
        });
    };

    self.deleteAllSelected = function () {
        self.database.removeAll(ColorSoft.Urls.DeleteUsers, self.selectedUsers(),
        function (result) {
            _.each(self.selectedUsers(), function (user) {
                self.users.remove(user);
            });
        },
        function () {
            alert("Error while deleting all selected users.");
        });
    };

    self.addUser = function () {
        location.hash = "#/Users/Add";
    };

    self.editUser = function (user) {
        user.editing(true);
    };

    self.cancelEditingUser = function (user) {
        user.editing(false);
    };

    self.updateUser = function (user) {
        user.editing(false);
        user.update();
    };

    self.confirmDeleteUser = function (user) {
        self.userToDelete(user);
        self.deleteDialog.modal("show");
    };

    self.deleteUser = function () {
        var user = self.userToDelete();
        self.closeDeleteConfirm();
        self.database.remove(ColorSoft.Urls.DeleteUser, user, function (result) {
            self.users.remove(user);
        },
        function () {
            alert("Error while deleting selected user.");
        });
    };

    self.closeDeleteConfirm = function () {
        self.userToDelete(null);
        self.deleteDialog.modal("hide");
    };

    self.displayMode = function (user) {
        return user.editing() ? "edit-template" : "view-template";
    };
};