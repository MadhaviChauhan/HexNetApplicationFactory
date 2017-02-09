
//controller initialization for displaying of single customer
appcustomer.controller("singleCustomerController", singleCustomerController);

singleCustomerController.$inject=['$scope', '$uibModalInstance', 'routeParams', 'SPACRUDService', 'WebApiUrl','resourceProvider'];

function singleCustomerController($scope, $uibModalInstance, routeParams, SPACRUDService, WebApiUrl,resourceProvider) {

    getCustomer();
    function getCustomer() {
        var promiseCustomer = SPACRUDService.getCustomer(WebApiUrl,routeParams.entity.Id);


        promiseCustomer.then(function (pl) {
            $scope.Customer = pl;
        })
        .catch(function(e){$scope.error = resourceProvider.getCustomerError();});
            
    }
    $scope.cancelView = cancelView;
    function cancelView() { $uibModalInstance.dismiss(); };


};