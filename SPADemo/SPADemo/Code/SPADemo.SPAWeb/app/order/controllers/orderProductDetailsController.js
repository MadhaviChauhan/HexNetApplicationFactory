//initialize controller for order module, inside function used all the parameters which would require for further operations inside controller
apporder.controller("orderProductDetailsController", orderProductDetailsController);

orderProductDetailsController.$inject=['$scope', '$uibModalInstance', 'routeParams', 'SPAOrderService', 'uiGridConstants', 'WebApiUrl','resourceProvider'];

function orderProductDetailsController($scope, $uibModalInstance, routeParams, SPAOrderService, uiGridConstants, WebApiUrl,resourceProvider) {
//function gets called when the view gets loaded for the defined controller
getOrderDetails();
$scope.OrderDetails = [];
function getOrderDetails(){
    
    //service call to get details
    var orderDetails = SPAOrderService.getOrderDetails(WebApiUrl, routeParams.entity.Id);
    
    //if success or error from service call
    orderDetails.then(function (pl) {
        $scope.OrderDetails = pl;
    }).catch(function (e) { $scope.error = resourceProvider.orderDetailError(); });

    var productDetails = SPAOrderService.getProductDetails(WebApiUrl, routeParams.entity.Id);

    productDetails.then(function (pl) {
        $scope.ProductDetails = pl;
    }).catch(function(e){$scope.error=resourceProvider.productDetailError();});
};
//assigning grid inputs
$scope.gridOptions = {

   enableColumnResizing: true,//required to enable column resizing
   data:'ProductDetails',//binding of data from service call
    columnDefs: [{ field: 'Product.Name', displayName: 'Description'},
        { field: 'Product.IsInStock', displayName: 'Is In Stock' },
     { field: 'Quantity', displayName: 'Quantity' },
     { field: 'UnitPrice', displayName: 'Unit Price' },
     { field: 'Discount', displayName: 'Discount' },
     { field: 'TotalPrice', displayName: 'Total Price' }]

};
//cancel click closes the modal dialog, self closing by dismissing the dialog.$uibModalInstance is used for the dialog
$scope.cancelDetails = cancelDetails;
function cancelDetails() { $uibModalInstance.dismiss(); };
};