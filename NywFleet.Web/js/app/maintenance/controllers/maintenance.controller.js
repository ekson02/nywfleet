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
        vm.abnormalConditionList = [];
        vm.maintenanceCriteria = [];
        vm.engines = [];
        vm.uncheck = uncheck;
        vm.maintenance = null;
        vm.onPropertyChange = onPropertyChange;
        vm.addAbnormalCondition = addAbnormalCondition;
        vm.toggleEnginProperties = toggleEnginProperties;
        vm.toggleProperties = toggleProperties;
        vm.saveReport = saveReport;

        var engineProperties = ["oil", "coolant", "jetBearing", "jhpu", "belts"];

        function activate() {
            if ($stateParams.vesselId) {
                vm.selectedVesselId = $stateParams.vesselId;
                var promises = [getVesselInfo(), getMaintenanceCriteria(), getAbnormalConditions()];
                return $q.all(promises).then(onDataReady());
            }
        }

        function getMaintenanceCriteria() {
            return maintenanceService.getMaintenanceCriteria().then(function (data) {
                if (data) {
                    vm.maintenanceCriteria = data;
                }
                return vm.maintenanceCriteria;
            });
        }

        function getAbnormalConditions() {
            return maintenanceService.getAbnormalConditions().then(function (data) {
                var issueList = [];
                for (var i = 0; i < data.length; i++) {
                    issueList.push(data[i].displayName);
                }
                vm.abnormalConditionList = issueList;
                return vm.abnormalConditionList;
            });
        }

        function getVesselInfo() {
            return maintenanceService.getAllVesselById(vm.selectedVesselId).then(function (data) {
                vm.vessel = data;
                vm.maintenance = {
                    vesselId: data.vesselId,
                    abnormalConditions: "",
                    engineMaintenanceResults: [],
                    maintenanceCriteriaResults: []
                }

                for (var i = 0; i < data.vesselEngines.length; i++) {
                    var engine = data.vesselEngines[i];
                    vm.maintenance.engineMaintenanceResults.push({
                        vesselEngineId: engine.vesselEngineId,
                        name: engine.engine.engineName
                    });
                }

                console.log(vm.vessel);
                console.log(vm.maintenance);
                return vm.vessel;
            });
        }

        function addAbnormalCondition() {
            vm.maintenance.abnormalConditions += vm.selectedCondition + "; ";
            vm.selectedCondition = "";
        }

        function saveReport() {
            for (var i = 0; i < vm.maintenanceCriteria.length  ; i++) {
                vm.maintenance.maintenanceCriteriaResults.push(vm.maintenanceCriteria[i]);
            }
  
            maintenanceService.saveLog(vm.maintenance).then(function (data) {
                $state.go("done");
            });

        }

        function onDataReady() {
            logger.info('Activated maintenance View');
            return true;
        }

        function uncheck(engine, property, event) {
            engine.lastKnown = engine.lastKnown || {};
            if (engine.lastKnown[property] == event.target.value) {
                engine[property] = null;
            }
            engine.lastKnown[property] = engine[property];
        }

        function onPropertyChange(prop, event) {
            if (prop.lastKnownResult == event.target.value) {
                prop.inspectionResult = null;
            }
            prop.lastKnownResult = prop.inspectionResult;
        }

        function toggleEnginProperties(engine, value) {
            for (var i = 0; i < engineProperties.length; i++) {
                var property = engineProperties[i];
                engine[property] = value;
                if (!engine.lastKnown) {
                    engine.lastKnown = {};
                }
                engine.lastKnown[property] = value;
            }
        }

        function toggleProperties(value) {
            for (var i = 0; i < vm.maintenanceCriteria.length; i++) {
                var criteria = vm.maintenanceCriteria[i];
                criteria.inspectionResult = value.toString();
                criteria.lastKnownResult = value.toString();
            }
        }


        activate();
    }
})();
