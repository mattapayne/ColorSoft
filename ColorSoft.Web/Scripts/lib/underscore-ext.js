_.mixin({
    //this method takes a source collection, a collection of items to remove and a callback function that is used to determine whether an
    //item should be removed from the source collection
    removalAll: function (sourceCollection, itemsToRemoveCollection, comparisonCallback) {
        var newCollection = _.filter(sourceCollection, function (item) {
            var match = _.find(itemsToRemoveCollection, function (itemToRemove) {
                return comparisonCallback(item, itemToRemove);
            });

            return !match;
        });

        return newCollection;
    }
});