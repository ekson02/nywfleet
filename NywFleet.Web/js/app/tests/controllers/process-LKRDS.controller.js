(function () {
    "use strict";

    angular
        .module("app.tests")
        .controller("ProcessLKRDSTestsController", processLkrdsTestsController);

    processLkrdsTestsController.$inject = ["$q", "logger", '$stateParams', "testsService", "$state", "config", "_", "$window"];
    /* @ngInject */
    function processLkrdsTestsController($q, logger, $stateParams, testsService, $state, config, _, $window) {
        var vm = this;
        vm.selectedTestType = "";
        vm.processAnswer = processAnswer;
        vm.currentStep = 1;
        vm.pageInfo = null;
        vm.submitPage = submitPage;
        vm.errors = [];

        function activate() {
            if ($stateParams.testInfo && $stateParams.testInfo.testType) {
                vm.selectedTestType = $stateParams.testInfo.testType;
                var promises = [startTest()];
                return $q.all(promises).then(onDataReady);
            } else {
                $state.go(config.dashboardState)
            }
        }

        function startTest() {
            return testsService.startTest(vm.selectedTestType).then(function (data) {
                vm.pageInfo = data;
                return vm.pageInfo;
            });
        }

        function processAnswer(question, answer) {
            question.answer = answer;
        }

        function submitPage() {
            vm.errors = [];
            var pageData = {
                testId: vm.pageInfo.testId,
                testVersionId: vm.pageInfo.testVersionId,
                currentCategoryCode: vm.pageInfo.currentCategory.categoryCd
            };
            pageData.answers = [];
            var invalidAnswers = _.find(vm.pageInfo.questions, function (question) {
                return !question.answer;
            });

            $window.scrollTo(0, 0);
            if (invalidAnswers) {
                vm.errors.push({
                    title: "Incomplete",
                    message: "Please answer all of the questions and try again"
                });
                return;
            }

            _.each(vm.pageInfo.questions, function (question) {
                pageData.answers.push({
                    questionId: question.questionId,
                    answer: question.answer
                })
            });

            testsService.submitPage(pageData).then(function (data) {
                if (data.isCompleted) {
                    $window.location.href = data.testResultUrl;
                }

                vm.pageInfo = data;
                vm.currentStep++;

            });
        }

        function onDataReady() {
            logger.info('Activated LKRDS  View');
            console.log(vm.pageInfo)
            return true;
        }


        activate();
    }
})();
