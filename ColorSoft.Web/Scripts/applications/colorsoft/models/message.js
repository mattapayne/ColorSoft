angular.module("colorSoft").factory("Message", ['ModelBase', function(ModelBase) {
    return function(args) {

        args = args || {
            Id: '',
            Subject: '',
            Message: '',
            CreatedAt: '',
            Email: ''
        };

        angular.extend(this, args, new ModelBase());
    };
}]);