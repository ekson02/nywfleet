(function () {
    "use strict";

    angular
      .module("app.maintenance")
      .controller("ThankYouController", thankYouController);

    thankYouController.$inject = ["$q", "logger", '$stateParams', "$state", "maintenanceService"];

    function thankYouController($q, logger, $stateParams, $state, maintenanceService) {
        var vm = this;
        vm.selectedTestType = "";
        vm.testInfo = null;
        vm.messageCount = 0;
        vm.vessels = [];

        function activate() {
            //var promises = [getVessels()];
            //return $q.all(promises).then(onDataReady());
        }
        
        function getVessels() {
            return maintenanceService.getAllVessels().then(function (data) {
                vm.vessels = data;
                return vm.vessels;
            });
        }

        
        function onDataReady() {
            logger.info("Thank you");
            return true;
        }


        activate();
    }
})();
