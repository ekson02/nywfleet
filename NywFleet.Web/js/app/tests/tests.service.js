(function () {
    "use strict";
    angular.module("app.tests")
        .factory("testsService", testsService);

    testsService.$inject = ["$http", "config", "exception"];
    function testsService($http, config, exception) {
        var service = {
            getTestInfo: getTestInfo,
            startTest: startTest,
            submitPage: submitPage
        }
        return service;
        ///----

        function getTestInfo(testType) {
            return $http.get(config.apiUrl + "lookup/test-type/" + testType).then(function (response) {
                return {
                    testInfo: response.data
                };
            }).catch(fail);
        };

        function startTest(testType) {
            var data = {testTypeCd: testType};
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