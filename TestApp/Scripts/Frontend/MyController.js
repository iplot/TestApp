(function() {

    angular
        .module('app', [])
        .controller('MyController', MyController);

    MyController.$inject = [
        '$scope',
        '$http'
    ];

    function MyController($scope, $http) {
        $scope.linkClick = linkClick;

        (function() {
            sendPath("");
        })();

        function linkClick(index) {
            var path = $scope.folderInfo.CurrentDir + $scope.folderInfo.BrowseList[index];

            sendPath(path);
        }

        function sendPath(path) {
            var url = path === '' ? '/api/folder' : '/api/folder?path=' + path;
            $http({
                'method': 'GET',
                'url': url
            }).then(function (response) {
                $scope.folderInfo = response.data;
            });
        }
    }
})();