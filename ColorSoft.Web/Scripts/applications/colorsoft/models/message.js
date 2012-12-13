ColorSoft.Models = ColorSoft.Models || {};

/***************** Model *******************/
ColorSoft.Models.Message = function (data) {
    var self = this;
    self.Id = ko.observable(data.Id);
    self.Email = ko.observable(data.Email);
    self.Subject = ko.observable(data.Subject);
    self.Message = ko.observable(data.Message);
    self.CreatedAt = ko.observable(data.CreatedAt);
    self.isSelected = ko.observable(false);
};