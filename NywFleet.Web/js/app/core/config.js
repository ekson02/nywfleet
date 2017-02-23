(function () {
    "use strict";
    var core = angular.module("app.core");
    core.config(toastrConfig);
    toastrConfig.$inject = ["toastr"];
    function toastrConfig(toastr) {
        toastr.options.timeOut = 2000;
        toastr.options.positionClass = "toast-bottom-right";
    }

    var config = {
        appErrorPrefix: "[5QTest Error] ",
        appTitle: "5QTest",
        loginState: "login",
        dashboardState: "dashboard",
        apiUrl: "/api/"
    };

    core.value("config", config);
    core.config(configure);
    configure.$inject = ["$logProvider", "routerHelperProvider", "exceptionHandlerProvider"];   
    function configure($logProvider, routerHelperProvider, exceptionHandlerProvider) {
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
        exceptionHandlerProvider.configure(config.appErrorPrefix);
        routerHelperProvider.configure({ docTitle: config.appTitle + ": " });
    }

})();
