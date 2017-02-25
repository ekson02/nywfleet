(function () {
    "use strict";

    angular
      .module("app.maintenance")
      .controller("MaintenanceController", maintenanceController);

    maintenanceController.$inject = ["$q", "logger", '$stateParams', "$state", "maintenanceService"];
    function maintenanceController($q, logger, $stateParams, $state, maintenanceService) {
        var vm = this;
        vm.selectedVesselId = "";

        vm.messageCount = 0;
        vm.vessel = null;
        vm.abnormalConditions = [];
        vm.maintenanceCriteria = [];


        function activate() {
            if ($stateParams.vesselId) {
                vm.selectedVesselId = $stateParams.vesselId;
                var promises = [getVesselInfo(), getMaintenanceCriteria(), getAbnormalConditions()];
                return $q.all(promises).then(onDataReady());
            }
        }


        function getMaintenanceCriteria() {
            return maintenanceService.getMaintenanceCriteria().then(function (data) {
                vm.maintenanceCriteria = data;
                return vm.maintenanceCriteria;
            });
        }

        function getAbnormalConditions() {
            return maintenanceService.getAbnormalConditions().then(function (data) {
                vm.abnormalConditions = data;
                return vm.abnormalConditions;
            });
        }


        function getVesselInfo() {
            return maintenanceService.getAllVesselById(vm.selectedVesselId).then(function (data) {
                vm.vessel = data;
                return vm.vessel;
            });
        }


        function onDataReady() {
            logger.info('Activated maintenance View');
            return true;
        }


        activate();
    }
})();
