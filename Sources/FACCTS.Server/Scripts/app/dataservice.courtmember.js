define('dataservice.courtmember',
    ['amplify'],
    function (amplify) {
        var
            init = function () {

                var baseUrl = '/FACCTS.Server/Admin/api/';

                amplify.request.define('courtMemberBriefs', 'ajax', {
                    url: baseUrl + 'CourtMemberBrief',
                    dataType: 'json',
                    type: 'GET'
                });

                // Pass Resource Id, Request Type, and Settings
                amplify.request.define('courtMemberbyid', 'ajax', {
                    url: baseUrl + 'courtmembers/memberbyid/{id}',
                    dataType: 'json',
                    type: 'GET'
                    //cache: true
                    //cache: 60000 // 1 minute
                    //cache: 'persist'
                });
                // Pass Resource Id, Request Type, and Settings
                amplify.request.define('courtMemberbyName', 'ajax', {
                    url: baseUrl + 'courtmembers/memberbyname/{name}',
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

                //amplify.request.define('courtMemberUpdate', 'ajax', {
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

           getCourtMemberByName = function (callbacks, name) {
               return amplify.request({
                   resourceId: 'courtMemberbyname',
                   data: { name: name },
                   success: callbacks.success,
                   error: callbacks.error
               });
           },

            getCourtMemberById = function (callbacks, id) {
                return amplify.request({
                    resourceId: 'courtMemberbyid',
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
            getCourtMemberBriefs: getCourtMemberBriefs,
            getCourtMemberByName: getCourtMemberByName,
            getCourtMemberById: getCourtMemberById
        };
    });