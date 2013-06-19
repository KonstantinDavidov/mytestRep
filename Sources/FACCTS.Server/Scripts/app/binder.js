define('binder',
    ['jquery', 'ko', 'config', 'vm'],
    function ($, ko, config, vm) {
        var
            ids = config.viewIds,

            bind = function () {
                debugger;
                ko.applyBindings(vm.courtstaff, getView(ids.courtstaff));
                vm.courtstaff.activate();
                //ko.applyBindings(vm.courtsettings, getView(ids.courtsettings));
            },

            getView = function (viewName) {
                debugger;
                return $(viewName).get(0);
            };

        return {
            bind: bind
        };
    });