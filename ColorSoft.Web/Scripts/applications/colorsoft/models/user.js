ColorSoft.Models = ColorSoft.Models || {};

/***************** Model *******************/
ColorSoft.Models.User = function (data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.FirstName = ko.observable(data.FirstName);
    self.LastName = ko.observable(data.LastName);
    self.EmailAddress = ko.observable(data.EmailAddress);
    self.UserName = ko.observable(data.UserName);
    self.CreatedAt = ko.observable(data.CreatedAt);
    self.editing = ko.observable(false);
    self.isSelected = ko.observable(false);
};