angular.module("colorSoft").factory("User", ['ModelBase', function (ModelBase) {
    return function (args) {
        
        args = args || {
            Id: '',
            FirstName: '',
            LastName: '',
            EmailAddress: '',
            FullName: '',
            UserName: '',
            OrganizationName: '',
            OrganizationId: '',
            CreatedAt: ''
        };

        angular.extend(this, args, new ModelBase());
    };
}])