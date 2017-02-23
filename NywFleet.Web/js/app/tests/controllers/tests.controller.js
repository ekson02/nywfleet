(function () {
    "use strict";

    angular
      .module("app.tests")
      .controller("TestsController", testsController);

    testsController.$inject = ["$q", "logger", '$stateParams', "$state", "testsService"];
    /* @ngInject */
    function testsController($q, logger, $stateParams, $state, testsService) {
        var vm = this;
        vm.selectedTestType = "";
        vm.testInfo = null;
        vm.messageCount = 0;
        vm.startTest = startTest;
        vm.title = "Tests";



        function activate() {
            if ($stateParams.type) {
                vm.selectedTestType = $stateParams.type;
                var promises = [getTestInfo()];
                return $q.all(promises).then(onDataReady());

            }
        }

        function startTest() {

            $state.go("testProcess" + vm.selectedTestType, { testInfo: { testType: vm.selectedTestType } });
        }
        function getTestInfo() {
            return testsService.getTestInfo(vm.selectedTestType).then(function (data) {
                vm.testInfo = data.testInfo;
                return vm.testInfo;
            });
        }


        function onDataReady() {
            logger.info('Activated Test View');
            return true;
        }


        activate();
    }
})();
