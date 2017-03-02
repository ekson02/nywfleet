(function () {
    "use strict";

    angular
      .module("app.maintenance")
      .controller("VesselSelectionController", vesselSelectionController);

    vesselSelectionController.$inject = ["$q", "logger", '$stateParams', "$state", "maintenanceService"];

    function vesselSelectionController($q, logger, $stateParams, $state, maintenanceService) {
        var vm = this;
        vm.selectedTestType = "";
        vm.testInfo = null;
        vm.messageCount = 0;
        vm.title = "Tests";
        vm.vessels = [];
        vm.selectVessel = selectVessel;

        function activate() {
            var promises = [getVessels()];
            return $q.all(promises).then(onDataReady());
        }
        
        function getVessels() {
            return maintenanceService.getAllVessels().then(function (data) {
                vm.vessels = data;
                return vm.vessels;
            });
        }

        function selectVessel(vessel) {
            if (vessel) {
                
                $state.go("maintenance", { vesselId: vessel.vesselId });
            }
        }

        function onDataReady() {
            logger.info('Activated maintenance View');
            return true;
        }


        activate();
    }
})();
