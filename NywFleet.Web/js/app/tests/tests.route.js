(function () {
    "use strict";

    angular
        .module("app.tests")
        .run(appRun);

    appRun.$inject = ["routerHelper"];
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [{
            state: "dashboard",
            config: {
                url: "/dashboard",
                params: {
                    bodyClass: "page"
                },
                views: {
                    'mainContent': {
                        templateUrl: "/js/app/tests/templates/tests.html",
                        controller: "TestsController",
                        controllerAs: "vm"
                    }
                },
                title: "Dashboard"
            }
        },
            {
                state: "testInfo",
                config: {
                    url: "/info/:type",
                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/tests/templates/test-info.html",
                            controller: "TestsController",
                            controllerAs: "vm"
                        }
                    }
                }
            },
            {
                state: "testProcessSRTSK",
                config: {
                    url: "/process-srtsk",
                    params: {
                        testInfo: null,
                        bodyClass: "test-page"
                    },
                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/tests/templates/test-process-srtsk.html",
                            controller: "ProcessSRTSKTestsController",
                            controllerAs: "vm"
                        }
                    }
                }
            },
            {
                state: "testProcessLKRDS",
                config: {
                    url: "/process-lkrds",
                    params: {
                        testInfo: null,
                        bodyClass: "test-page"
                    },

                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/tests/templates/test-process-lkrds.html",
                            controller: "ProcessLKRDSTestsController",
                            controllerAs: "vm"
                        }
                    }
                }
            }
        ];
    }
})();
