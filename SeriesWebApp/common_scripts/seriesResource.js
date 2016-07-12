(function () {
    "use strict";

    angular
        .module("common.service")
        .factory("seriesResource", ["$resource", "appSettings", seriesResource])

    function seriesResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/home/:maxSeriesTerm");
    }


}());

