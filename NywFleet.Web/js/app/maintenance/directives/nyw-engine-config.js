(function () {
    'use strict';
    angular.module('app.maintenance').directive('nywEngineConfig', nywEngineConfig);
    function nywEngineConfig() {
        var directive = {
            templateUrl: '/js/app/maintenance/directives/nyw-engine-config.html',
            restrict: 'EA'
            
        };
        return directive;

    }

})();
