define('dataprimer',
    ['ko', 'datacontext', 'config'],
    function (ko, datacontext, config) {

        var logger = config.logger,

            fetch = function () {

                return $.Deferred(function (def) {

                    var data = {
                        courtmember: ko.observable(),
                    };
                    debugger;
                    $.when(
                        datacontext.courtmembers.getData({ results: data.courtmember })
                    )

                    .pipe(function () {
                        // Need sessions and speakers in cache before
                        // speakerSessions models can be made (client model only)
                        //datacontext.speakerSessions.refreshLocal();
                    })

                    .pipe(function () {
                        logger.success('Fetched data for: '
                            + '<div>' + data.courtmember().length + ' courtmember </div>'
                        );
                    })

                    .fail(function () { def.reject(); })

                    .done(function () {
                        def.resolve();
                    });

                }).promise();
            };

        return {
            fetch: fetch
        };
    });