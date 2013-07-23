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
                 datacontext.courtmembers.getData({
                 results: courtmembersbriefs
             });
        },

        onselect = function(item)
        {
            selectedcourtmemberbriefid(item.userId());
            refresh();
        },
        setSelectedCourtMemberBriefId = function()
        {
            if (courtmembersbriefs().length > 0) {
                selectedcourtmemberbriefid(courtmembersbriefs()[0].userId());
            }
        },
         refresh = function (callback) {
             $.when(
                 datacontext.courtmembers.getCourtmemberById(
                    selectedcourtmemberbriefid(),
                    {
                          success: function(s) {
                          selectedcourtmember(s);
                              //callback();
                          },
                          error: function(){ alert(error)}//callback
              }, true))
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