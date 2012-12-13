window.ColorSoft = window.ColorSoft || { };

window.ColorSoft.Authentication = {
    defaultOptions: {
        username: '',
        status: ''
    },

    showLoginPopup: function(options) {
        options = options || { };
        options = $.extend({ }, this.defaultOptions, options);

        if (options.status && options.status === 'failed') {
            var authMenu = $("ul#auth");
            var usernameElement = $("#Username", authMenu);
            var passwordElement = $("#Password", authMenu);
            usernameElement.val(options.username).addClass("field-error");
            passwordElement.addClass("field-error");
            $(".dropdown-toggle", authMenu).dropdown("toggle");

            var loginContainer = $("#auth");

            $("input, label", loginContainer).click(function(e) {
                e.stopPropagation();
            });
            

            loginContainer.popover({
                animation: true,
                placement: 'right',
                trigger: 'manual',
                content: "Your login attempt failed. Please try again.",
                title: 'Login Failed'
            });
            loginContainer.popover("show");
        }
    }
};

window.ColorSoft.Utilities = {
    validateEmail: function (potentialEmail) {
        var re = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        var valid = re.test(potentialEmail);
        return valid;
    }
};

Array.prototype.remove = function () {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};

$(function () {
    $("#" + window.ColorSoft.TopNavigation.SelectedMenuItem).addClass("active");
    $("#logout-link").click(function (e) {
        e.preventDefault();
        $("#logout-form").submit();
    });

    $("#validation-errors-container").on("click", ".validation-error-indicator", function (e) {
        e.preventDefault();
        var indicator = $(e.currentTarget);
        var field = indicator.data("invalid-field");
        $("#" + field).focus();
    });
});