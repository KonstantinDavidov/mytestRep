define('vm.courtstaff',
    ['jquery', 'ko', 'datacontext', 'router', 'group', 'utils', 'config', 'event.delegates', 'messenger', 'store'],
    function ($, ko, datacontext, router, group, utils, config, eventDelegates, messenger, store) 
    {
        var
            courtmembersbriefs = ko.observableArray(),
            selectedcourtmemberbriefid = ko.observable(),
            selectedcourtmember = ko.observable(),
            init = function () { },



        // Methods
        activate = function (routeData, callback) {
            debugger;
            getCourtMemberBriefs();
            setSelectedCourtMemberBriefId();
            refresh(callback);
        },

         dataOptions = function (force) {
             return {
                 results: sessions,
                 filter: sessionFilter,
                 sortFunction: sort.sessionSort,
                 forceRefresh: force,
                 currentUserId: config.currentUserId

             };
         },
         getCourtMemberBriefs = function () {
                 datacontext.courtmember.getData({
                 results: courtmembersbriefs
             });
        },

        onselect = function(item)
        {
            selectedcourtmemberbriefid(item.userId);
        },
        setSelectedCourtMemberBriefId = function()
        {
            if (courtmembersbriefs().length > 0) {
                selectedcourtmemberbriefid(courtmembersbriefs()[0]);
            }
        },
         refresh = function (callback) {
             $.when(datacontext.courtmember.getCourtmemberById(selectedcourtmemberbriefid(), , true))
                 .always(utils.invokeFunctionIfExists(callback));
         };

        init();

        return {
            activate : activate,
            courtmembersbriefs: courtmembersbriefs,
            selectedcourtmemberbriefid : selectedcourtmemberbriefid,
            onselect: onselect,
            selectedcourtmember: selectedcourtmember
        };
    }

    );