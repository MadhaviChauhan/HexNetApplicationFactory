//controller intialization for customer delete
appcustomer.controller("deleteCustomerController", deleteCustomerController);
deleteCustomerController.$inject=['$scope','$uibModalInstance', 'routeParams', 'SPACRUDService','WebApiUrl','resourceProvider'];
function deleteCustomerController($scope,$uibModalInstance, routeParams, SPACRUDService,WebApiUrl,resourceProvider) {
//load customer data from service call
    getCustomer();
    function getCustomer() {
        
        var promiseCustomer = SPACRUDService.getCustomer(WebApiUrl,routeParams.entity.Id);


        promiseCustomer.then(function (pl) {
            $scope.Customer = pl;
        })
        .catch(function(e){$scope.error=resourceProvider.getCustomerError();});
    }
    //delete customer function from service
    $scope.deleteCustomer = deleteCustomer;
    function deleteCustomer() {
        var promiseDeleteCustomer = SPACRUDService.delete(WebApiUrl,routeParams.entity.Id);

        promiseDeleteCustomer.then(function () {
             $uibModalInstance.close(promiseDeleteCustomer);
        })
        .catch(function(e){$scope.error=resourceProvider.deleteCustomerError();});
    };

    $scope.cancelDelete = cancelDelete;
    function cancelDelete() { $uibModalInstance.dismiss(); };

};
