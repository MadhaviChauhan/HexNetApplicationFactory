//COntroller intitalization for customer edit
appcustomer.controller("editCustomerController", editCustomerController);

editCustomerController.$inject=['$scope', '$uibModalInstance', 'routeParams', 'SPACRUDService', 'WebApiUrl','resourceProvider'];
function editCustomerController($scope, $uibModalInstance, routeParams, SPACRUDService, WebApiUrl,resourceProvider) {
    //reading values from parent page parameter passed to dialog
    $scope.Id = routeParams.entity.Id;
    $scope.Name = routeParams.entity.Name;
    $scope.Address = routeParams.entity.Address;
    $scope.Phone = routeParams.entity.Phone;
    $scope.Email = routeParams.entity.Email;

    //function to call service for customer edit
    $scope.editCustomer = editCustomer;
    function editCustomer() {        
        var Customer = {
            Id:$scope.Id,
            Name: $scope.Name,
            Address: $scope.Address,
            Phone: $scope.Phone,
            Email: $scope.Email,

        };
        var promisePost = SPACRUDService.put(WebApiUrl,Customer);
        //closing dialog by passing result of service call
        promisePost.then(function () {            
                     $uibModalInstance.close(promisePost);
           
        })
        .catch(function(e){$scope.error=resourceProvider.editCustomerError();});


    };

    $scope.cancelEdit = cancelEdit;
    function cancelEdit() { $uibModalInstance.dismiss(); };
};