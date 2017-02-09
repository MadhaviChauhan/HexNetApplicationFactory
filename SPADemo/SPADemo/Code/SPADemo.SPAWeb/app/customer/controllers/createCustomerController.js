//controller intializatilization fro create customer
appcustomer.controller('createCustomerController', createCustomerController);
createCustomerController.$inject=['$scope','$uibModalInstance','$rootScope', 'SPACRUDService','WebApiUrl','resourceProvider'];
function createCustomerController($scope,$uibModalInstance,$rootScope, SPACRUDService,WebApiUrl,resourceProvider) {
   //function to call from service to create customer
    $scope.saveCustomer = saveCustomer;
    function saveCustomer() {
        var Customer = {
            Name: $scope.Name,
            Address: $scope.Address,
            Phone: $scope.Phone,
            Email: $scope.Email,
           
        };
        var promisePost = SPACRUDService.post(WebApiUrl,Customer);

        promisePost.then(function () {
           //on success from creating customer, call event on parent page to reload content of grid
              $rootScope.$emit('ReloadGrid');
               
             $uibModalInstance.close(promisePost);
        })
        .catch(function (e) { $scope.error = resourceProvider.createCustomerError(); });

       
    };
    $scope.cancelCreate = cancelCreate;
    function cancelCreate() { $uibModalInstance.dismiss(); };
    
};