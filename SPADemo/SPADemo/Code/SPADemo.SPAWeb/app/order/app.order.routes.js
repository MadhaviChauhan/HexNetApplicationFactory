//Showing Routing  for order related views
apporder.config(['$routeProvider', function ($routeProvider) {
      
    $routeProvider.when('/manageOrdersView',
                        {
                            templateUrl: 'order/views/manageOrdersView.html',
                            controller: 'manageOrdersController'
                        });
     $routeProvider.when('/orderProductDetailsView/:ID',
                        {
                            templateUrl: 'order/views/orderProductDetailsView.html',
                            controller: 'orderProductDetailsController'
                        });
}]);