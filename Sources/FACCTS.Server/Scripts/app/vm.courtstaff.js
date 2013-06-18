define('vm.courtstaff',
    ['jquery', 'ko', 'datacontext', 'router', 'group', 'utils', 'config', 'event.delegates', 'messenger', 'store'],
    function ($, ko, datacontext, router, group, utils, config, eventDelegates, messenger, store) {
        var
            sessionBriefs = ko.observableArray(),
            selectedMember = ko.observable(),
            init = function () { };
        init();
        return
        {
            sessionBriefs : sessionBriefs,
            selectedMember : selectedMember
        };

        });