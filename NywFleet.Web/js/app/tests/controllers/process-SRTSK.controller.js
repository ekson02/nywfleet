(function () {
    "use strict";

    angular
      .module("app.tests")
      .controller("ProcessSRTSKTestsController", processSrtskTestsController);

    processSrtskTestsController.$inject = ["$q", "logger", '$stateParams', "testsService"];
    /* @ngInject */
    function processSrtskTestsController($q, logger, $stateParams, testsService) {
        var vm = this;
        vm.selectedTestType = "";
        vm.testInfo = null;
        vm.messageCount = 0;
        vm.title = "Tests";
        vm.currentStep = 1;
        vm.pageInfo = null;
        //vm.submitPage = submitPage;
        vm.errors = [];
        vm.sortingLog = [];
        vm.questions = [
            { questionText: 'Item 5', questionId: 5 },
    {questionText: 'Item 3', questionId: 3 },
    {questionText: 'Item 1', questionId: 1 },
    {questionText: 'Item 6', questionId: 6 },
    {questionText: 'Item 2', questionId: 2 },
    {questionText: 'Item 4', questionId: 4 }];

        vm.questions.sort(function (a, b) {
            return a.i > b.i;
        });
        vm.sortableOptions = {
            stop: function (e, ui) {
                var possition = 0;
                for (var index in vm.questions) {
                    vm.questions[index].index = possition;
                    possition++;
                }

                logModels();
            }
        };
        

        function logModels() {
            var logEntry = vm.questions.map(function (i) {
                return i.questionText + '(pos:' + i.index + ')';
            }).join(', ');
            vm.sortingLog.push('Stop: ' + logEntry);
        }

        function activate() {
            //if ($stateParams.testInfo.testType) {
            //    vm.selectedTestType = $stateParams.testInfo.testType;
            //    var promises = [getTestInfo()];
            //    return $q.all(promises).then(onDataReady());
            //}
        }

        function getTestInfo() {
            return testsService.getTestInfo(vm.selectedTestType).then(function (data) {
                vm.testInfo = data.testInfo;
                return vm.testInfo;
            });
        }


        function onDataReady() {
            logger.info('Activated SRTSKT View');
            return true;
        }


        activate();
    }
})();
