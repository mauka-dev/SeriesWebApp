(function () {
    "use strict";

    angular
        .module("seriesApp")
        .controller("MainCtrl",
                    ["$resource", "appSettings", "seriesResource", "findSeriesElement", MainCtrl]);

    function MainCtrl($resource, appSettings, seriesResource, findSeriesElement) {
        var vm = this;
        vm.message = '';
        vm.userData = {
            divisor: 3,
            nIndex: 4,
            maxSeriesTerm: 15
        };
        vm.resultElement = '';
        vm.series = '';

        seriesResource.query({ maxSeriesTerm: vm.userData.maxSeriesTerm },
            function (data) {
                vm.message = ''; vm.series = data;
            });

        vm.loadSeries = function () {
            seriesResource.query({ maxSeriesTerm: vm.userData.maxSeriesTerm },
                function (data) {
                    vm.message = ''; vm.series = data;
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    vm.series = '';
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;
                })
        };

        vm.findElement = function () {
            vm.loadSeries();

            findSeriesElement.query({ maxSeriesTerm: vm.userData.maxSeriesTerm, divisor: vm.userData.divisor, nIndex: vm.userData.nIndex },
            function (data) {
                vm.message = ''; vm.resultElement = '';
                vm.resultElement = data[0];
            },
            function (response) {
                vm.message = response.statusText + "\r\n";
                vm.resultElement = '';
                if (response.data.exceptionMessage)
                    vm.message += response.data.exceptionMessage;
            }

           )
        };
    }
}());