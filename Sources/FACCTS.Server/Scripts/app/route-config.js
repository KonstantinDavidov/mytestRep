﻿define('route-config',
    ['config', 'router', 'vm'],
    function (config, router, vm) {
        var
            logger = config.logger,

            register = function () {

                var routeData = [

                    // CourtStaff routes
                    {
                        view: config.viewIds.courtstaff,
                        routes: [
                            {
                                isDefault: true,
                                route: config.hashes.courtstaff,
                                title: 'Court Staff',
                                callback: vm.courtstaff.activate,
                                group: '.route-top'
                            }
                        ]
                    }
                    //,

                    //// CourtSettings routes
                    //{
                    //    view: config.viewIds.courtsettings,
                    //    routes:
                    //        [{
                    //            route: config.hashes.courtsettings,
                    //            title: 'Court Settings',
                    //            callback: vm.courtsettings.activate,
                    //            group: '.route-top'
                    //        }]
                    //},

                    // Invalid routes
                    //{
                    //    view: '',
                    //    route: /.*/,
                    //    title: '',
                    //    callback: function () {
                    //        logger.error(config.toasts.invalidRoute);
                    //    }
                    //}
                ];

                for (var i = 0; i < routeData.length; i++) {
                    debugger;
                    router.register(routeData[i]);
                }

                // Crank up the router
                debugger;
                router.run();
            };


        return {
            register: register
        };
    });