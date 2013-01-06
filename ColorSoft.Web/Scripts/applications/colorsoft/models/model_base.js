angular.module("colorSoft").factory("ModelBase", function () {
    return function () {
        this.selected = false;
        this.editing = false;
        this.memento = null;

        this.IGNORED_PROPERTIES = ["selected", "editing", "memento", "IGNORED_PROPERTIES"];

        this.asJson = function () {
            return angular.toJson(this._createMemento());
        };

        this.isSelected = function () {
            return this.selected;
        };

        this.setSelected = function (selected) {
            this.selected = selected;
        };

        this.inEditMode = function () {
            return this.editing;
        };

        this.inViewMode = function () {
            return !this.editing;
        };

        this.setEditing = function (editing) {
            this.editing = editing;

            if (this.editing) {
                this.createMemento();
            } else {
                this.commit();
            }
        };

        this.cancelEditing = function () {
            if (this.editing) {
                this.restoreFromMemento();
                this.setEditing(false);
            }
        };

        this.restoreFromMemento = function () {
            if (this.memento != null) {
                for (var property in this.memento) {
                    if (this.hasOwnProperty(property) && !_.contains(this.IGNORED_PROPERTIES, property)) {
                        this[property] = this.memento[property];
                    }
                }

                this.memento = null;
            }
        };

        this.createMemento = function () {
            this.memento = this._createMemento();
        };

        this.commit = function () {
            this.memento = null;
        };

        this._createMemento = function () {
            var memento = {};
            for (var property in this) {
                if (this.hasOwnProperty(property) && !_.contains(this.IGNORED_PROPERTIES, property)) {
                    memento[property] = this[property];
                }
            }
            return memento;
        };
    };
});
