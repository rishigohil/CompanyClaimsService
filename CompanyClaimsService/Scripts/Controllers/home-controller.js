var homeController = function ($scope, $http) {
    $scope.models = {
        titleApp: 'Claims Application'
    };

    $scope.selectedDocument = null;
    $scope.xmlFiles = [];
    $scope.resultData = null;

    $http({
        method: 'GET',
        url: '/api/claims'
    }).success(function (result) {
        $scope.xmlFiles = result;
    });

    $scope.GetData = function () {
        var selectedDoc = $scope.selectedDocument;
        var paramDoc = selectedDoc.replace('.xml', '');
        var uri = '/api/claims/' + paramDoc;
        $http.get(uri)
            .success(function (data) {
                var temp = [];
                temp = angular.fromJson(JSON.parse(data));

                $scope.resultData = temp;
            });
    }
}

homeController.$inject = ['$scope', '$http'];

