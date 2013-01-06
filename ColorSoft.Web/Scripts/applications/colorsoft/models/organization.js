angular.module("colorSoft").factory("Organization", ['ModelBase', function(ModelBase) {
    return function(args) {
        args = args || {
            Id: '',
            Name: ''
        };

        angular.extend(this, args, new ModelBase());
    };
}]);

