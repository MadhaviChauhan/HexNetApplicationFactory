//Showing Routing  for customer related views
appcustomer.config(['$routeProvider', function ($routeProvider) {
     
    $routeProvider.when('/',
                        {
                            templateUrl: 'customer/views/allCustomerView.html',
                            controller: 'allCustomerController'
                        });
    $routeProvider.when('/createCustomerView',
                        {
                            templateUrl: 'customer/views/createCustomerView.html',
                            controller: 'createCustomerController'
                        });
    $routeProvider.when('/editCustomerView/:ID/:Name/:Address/:Phone/:Email',
                        {
                            templateUrl: 'customer/views/editCustomerView.html',
                            controller: 'editCustomerController'
                        });
    $routeProvider.when('/deleteCustomerView/:ID',
                        {
                            templateUrl: 'customer/views/deleteCustomerView.html',
                            controller: 'deleteCustomerController'
                        });
    $routeProvider.when('/singleCustomerView/:ID',
                       {
                           templateUrl: 'customer/views/singleCustomerView.html',
                           controller: 'singleCustomerController'
                       });
   
}]);