define('dataservice.courtmember',
    ['amplify'],
    function (amplify) {
        var
            init = function () {

                amplify.request.define('courtMemberBriefs', 'ajax', {
                    url: 'admin/api/CourtMemberBrief',
                    dataType: 'json',
                    type: 'GET'
                });

                // Pass Resource Id, Request Type, and Settings
                amplify.request.define('courtMemberbyId', 'ajax', {
                    url: 'admin/api/member/{id}',
                    dataType: 'json',
                    type: 'GET'
                    //cache: true
                    //cache: 60000 // 1 minute
                    //cache: 'persist'
                });
                // Pass Resource Id, Request Type, and Settings
                amplify.request.define('courtMemberbyName', 'ajax', {
                    url: 'admin/api/member/{id}',
                    dataType: 'json',
                    type: 'GET'
                    //cache: true
                    //cache: 60000 // 1 minute
                    //cache: 'persist'
                });

                //amplify.request.define('session', 'ajax', {
                //    url: '/api/sessions/{id}',
                //    dataType: 'json',
                //    type: 'GET'
                //});

                //amplify.request.define('sessionUpdate', 'ajax', {
                //    url: '/api/sessions',
                //    dataType: 'json',
                //    type: 'PUT',
                //    contentType: 'application/json; charset=utf-8'
                //});
            },

            getCourtMemberBriefs = function (callbacks) {
                return amplify.request({
                    resourceId: 'courtMemberBriefs',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            //getSessionBriefs = function (callbacks) {
            //    return amplify.request({
            //        resourceId: 'session-briefs',
            //        success: callbacks.success,
            //        error: callbacks.error
            //    });
            //},

            getCourtMember = function (callbacks, id) {
                return amplify.request({
                    resourceId: 'courtMember',
                    data: { id: id },
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

            //updateSession = function (callbacks, data) {
            //    return amplify.request({
            //        resourceId: 'sessionUpdate',
            //        data: data,
            //        success: callbacks.success,
            //        error: callbacks.error
            //    });
            //};

        init();

        return {
            getSessions: getSessions,
            getSessionBriefs: getSessionBriefs,
            getSession: getSession,
            updateSession: updateSession
        };
    });