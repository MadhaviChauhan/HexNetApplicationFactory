//order service initialization, which would call all the webapi for customer related operations

appcustomer.service("SPACRUDService", function ($http,$q) {
   
    
    this.getCustomers = getCustomers;
    
    function getCustomers(WebApiUrl) {
        var deferred = $q.defer();

        $http.get(WebApiUrl + 'api/Customer/')
            .success(function (data) {
                deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            })

            return deferred.promise;;
    };

    //Fundction to Read customer by filter 
    this.getCustomersByFilter =getCustomersByFilter;

    function getCustomersByFilter(WebApiUrl, filterObject, sortObject) {
        var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Customer/CustomerByFilter/?filterObject=' + filterObject + '&sortObject=' + sortObject)
            .success(function (data) {
            deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            })

            return deferred.promise;;
    };

    //Fundction to Read customer by customer ID  
    this.getCustomer =getCustomer;

    function getCustomer(WebApiUrl, id) {
       
         var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Customer/' + id)
             .success(function (data) {
                deferred.resolve(data);
                }).error(function (response) {
                    deferred.reject(response);
                })

            return deferred.promise;;
    };

    //Function to create new customer  
    this.post = post;


    function post(WebApiUrl, Customer) {
         var deferred = $q.defer();
        $http({
            method: "post",
            url: WebApiUrl + 'api/Customer/',
            data: Customer
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    //Edit customer    
    this.put = put;

    function put(WebApiUrl, Customer) {
        var deferred = $q.defer();
        $http({
            method: "put",
            url: WebApiUrl + 'api/Customer/',
            data: Customer
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };

    //Delete customer By customer id  
     this.delete = deleteCustomer;
     function deleteCustomer(WebApiUrl,id) {
      var deferred = $q.defer();
       $http({
            method: "delete",
            url: WebApiUrl + 'api/Customer/' + id
            }).success(function (data) {
                deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };
});