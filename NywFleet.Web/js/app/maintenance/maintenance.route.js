(function () {
    "use strict";

    angular
        .module("app.maintenance")
        .run(appRun);

    appRun.$inject = ["routerHelper"];
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [{
            state: "vessel-selector",
            config: {
                url: "/vessel-selector",
                params: {
                    bodyClass: ""
                },
                views: {
                    'mainContent': {
                        templateUrl: "/js/app/maintenance/templates/vessel-selection.html",
                        controller: "VesselSelectionController",
                        controllerAs: "vm"
                    }
                },
                title: "Dashboard"
            }
        },
            {
                state: "maintenance",
                config: {
                    url: "/maintenance/:vesselId",
                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/maintenance/templates/maintenance.html",
                            controller: "MaintenanceController",
                            controllerAs: "vm"
                        }
                    }
                }
            },
            {
                state: "done",
                config: {
                    url: "/done",
                    views: {
                        'mainContent': {
                            templateUrl: "/js/app/maintenance/templates/done.html",
                            controller: "ThankYouController",
                            controllerAs: "vm"
                        }
                    }
                }
            }

           
        ];
    }
})();
