(function ($, _) {

    var colorsoft = $.sammy("#dashboard-content", function () {

        this.use(Sammy.Template, "html");

        this.before({}, function () {
            this.app.swap("Loading ...");
        });

        this.get("#/", function (context) {
            context.app.swap("");
        });

        this.get("#/Users", function (context) {
            this.render('Content/templates/users/index.html').swap(function () {
                ko.applyBindings(new window.ColorSoft.ViewModels.UsersViewModel());
            });
        });

        this.get("#/Users/Add", function (context) {
            console.log("Add user");
        });

        this.get("#/Products", function (context) {
            console.log("Products");
        });

        this.get("#/Products/Add", function (context) {
            console.log("Add Product");
        });

        this.get("#/ColorMatches/Search", function (context) {
            console.log("Search color matches");
        });

        this.get("#/ColorMatches/Add", function (context) {
            console.log("Add color match");
        });

        this.get("#/Organizations", function (context) {
            console.log("Organizations");
        });

        this.get("#/Messages", function (context) {
            this.render('Content/templates/messages/index.html').swap(function() {
                ko.applyBindings(new window.ColorSoft.ViewModels.MessagesViewModel());
            });
        });
    });

    $(function () {
        colorsoft.run('#/');
    });

})(jQuery, _);