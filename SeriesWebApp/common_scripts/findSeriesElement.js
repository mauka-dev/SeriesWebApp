(function () {
    "use strict";

    angular
        .module("common.service")
        .factory("findSeriesElement", ["$resource", "appSettings", findSeriesElement])

    function findSeriesElement($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/home/findElement/:maxSeriesTerm/:divisor/:nIndex");
    }


}());

