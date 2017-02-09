//order service initialization, which would call all the webapi for order related operations
apporder.service("SPAOrderService", function ($http,$q) {
   
    this.search = search;
    function search(WebApiUrl, orderNo,customer,orderDateFrom,orderDateTo,salesPerson,carrier,status) {
        var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Order/GetOrders/?status=' + status + '&orderNo=' + orderNo + '&customer=' + customer + '&orderDateFrom=' + orderDateFrom + '&orderDateTo='+orderDateTo+'&salesPerson=' + salesPerson+'&carrier='+carrier)
            .success(function (data) {
                deferred.resolve(data);
            }).error(function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    };
    this.searchBasedonSort = searchBasedonSort;
    function searchBasedonSort(WebApiUrl, orderNo, customer, orderDateFrom, orderDateTo, salesPerson, carrier, status, sortObject) {
        var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Order/GetOrdersBySort/?status=' + status + '&orderNo=' + orderNo + '&customer=' + customer + '&orderDateFrom=' + orderDateFrom + '&orderDateTo=' + orderDateTo + '&salesPerson=' + salesPerson + '&carrier=' + carrier + '&sortObject=' + sortObject)
             .success(function (data) {
                 deferred.resolve(data);
             }).error(function (response) {
                 deferred.reject(response);
             });

        return deferred.promise;
    };

    this.getOrderDetails = getOrderDetails;
    function getOrderDetails(WebApiUrl, ID) {
        var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Order/OrderDetails/' + ID)
             .success(function (data) {
                 deferred.resolve(data);
             }).error(function (response) {
                 deferred.reject(response);
             });

        return deferred.promise;
    };

   
    this.getProductDetails=getProductDetails;
    function getProductDetails(WebApiUrl, ID) {
        var deferred = $q.defer();
        $http.get(WebApiUrl + 'api/Order/ProductDetails/' + ID)
             .success(function (data) {
                 deferred.resolve(data);
             }).error(function (response) {
                 deferred.reject(response);
             });

        return deferred.promise;
    };
});