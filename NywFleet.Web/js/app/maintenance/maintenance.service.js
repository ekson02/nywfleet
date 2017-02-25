(function () {
    "use strict";
    angular.module("app.maintenance")
        .factory("maintenanceService", maintenanceService);

    maintenanceService.$inject = ["$http", "config", "exception"];
    function maintenanceService($http, config, exception) {
        var service = {
            getAllVessels: getAllVessels,
            getAllVesselById: getAllVesselById,
            getMaintenanceCriteria: getMaintenanceCriteria,
            getAbnormalConditions: getAbnormalConditions
        }
        return service;
        ///----

        function getAllVessels() {
            return $http.get(config.apiUrl + "vessels/").then(function (response) {
                return success(response);
            }).catch(fail);
        };
        function getAllVesselById(vesselId) {
            return $http.get(config.apiUrl + "vessels/" + vesselId).then(function (response) {
                return success(response);
            }).catch(fail);
        };

        function getMaintenanceCriteria(vesselId) {
            return $http.get(config.apiUrl + "lookup/maintenance-criteria").then(function (response) {
                return success(response);
            }).catch(fail);
        };


        function getAbnormalConditions(vesselId) {
            return $http.get(config.apiUrl + "lookup/abnormal-conditions").then(function (response) {
                return success(response);
            }).catch(fail);
        };


        function startTest(testType) {
            var data = { testTypeCd: testType };
            return $http.post(config.apiUrl + "test", data).then(function (response) {
                return success(response);
            }).catch(fail);
        };

        function submitPage(data) {
            return $http.put(config.apiUrl + "test", data).then(function (response) {
                return success(response);
            }).catch(fail);
        }

        function fail(error) {
            return exception.catcher("")(error);
        }

        function success(response) {

            return response.data;
        }

    }

})();