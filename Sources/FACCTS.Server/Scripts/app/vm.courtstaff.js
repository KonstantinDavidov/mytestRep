define('vm.courtstaff',
    ['jquery', 'ko', 'datacontext', 'router', 'group', 'utils', 'config', 'event.delegates', 'messenger', 'store'],
    function ($, ko, datacontext, router, group, utils, config, eventDelegates, messenger, store) 
    {
        var
            courtmembersbriefs = ko.observableArray(),
            selectedMember = ko.observable(),
            init = function () { };

        init();

        return{
            courtmembersbriefs: courtmembersbriefs,
            selectedMember : selectedMember
        };
    }

    );