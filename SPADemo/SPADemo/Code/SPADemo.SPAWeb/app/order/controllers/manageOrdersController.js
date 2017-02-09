//initialize controller for order module, inside function used all the parameters which would require for further operations inside controller
//$uibModal used to open modal dialog from parent page
apporder.controller("manageOrdersController", manageOrdersController);
manageOrdersController.$inject=['$scope', '$uibModal', 'SPAOrderService','appFactory', 'uiGridConstants', 'WebApiUrl','resourceProvider'];

function manageOrdersController($scope, $uibModal, SPAOrderService,appFactory, uiGridConstants, WebApiUrl,resourceProvider) {
    
    //this is to populate dropdown on the view
    $scope.OrderStatus = {
        "type": "select",
        "name":"Select Status",
        "value": "Select Status",
        "values": ["Select Status", "Approved", "On-Hold", "Pending","Rejected"]
    };
    //pagination options
    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };

    //grid initialization
    $scope.gridOptions = {
       
        multiSelect: false,
        paginationPageSizes: [25,50,75,100,200,300,400, 500,600,700,800,900, 1000],//list of options available to load no. of items in grid
        paginationPageSize: 25,//initial page size
        useExternalPagination: true,//used when performing server side pagination
        enableColumnResizing: true,
        enableSelectAll: false, useExternalSorting:true,
        enableRowSelection: true, //to select row when anywhere in row is clicked
        noUnselect: true, //to select new row and unselect the currently selected row
        enableRowHeaderSelection: false,//to disable header row selection
        columnDefs: [{ field: 'Id', displayName: 'Order No.' },
            { field: 'CustomerId', displayName: 'Customer ID' },
         { field: 'Customer.Name', displayName: 'Customer Name'}, { field: 'Customer.Address', displayName: 'Address'},
         { field: 'OrderDate', displayName: 'Order Date'}, { field: 'Carrier', displayName: 'Carrier' },
         { field: 'SalesPerson', displayName: 'SalesPerson'},
         { field: 'Boxes', displayName: 'Boxes'},
         { field: 'TotalCost', displayName: 'Total Cost'},
         { field: 'OrderStatus', displayName: 'Order Status'},
         { field: 'Action', enableColumnMenu: false, enableFiltering: false, displayName: '', cellTemplate: '<button type="button" class="btn btn-sm btn-primary" ng-click="grid.appScope.view(row)">Order Details</button>' }]//action to open dialog for order details, grid.appscope is used to open dialog when button is clicked from grid

    };
    //open dialog for order details
    $scope.view=view;
    function view(row){
        var modalInstance =  $uibModal.open({
            
            templateUrl: 'order/views/orderProductDetailsView.html',//url of orderdetails page
            controller: 'orderProductDetailsController',
            resolve: {
                routeParams: function () {
                    return row;
                }//this is the parameter which will be passed to order details page for operations to be performed on dialog page
            }
        });       

    };
    //registering api events on grid for row selection and pagination
    $scope.gridOptions.onRegisterApi = registerApi;
    function registerApi(gridApi) {

        //set gridApi on scope
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            var msg = row.entity.ID;

        });
        gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
            
            var SearchCriteria = {
                OrderNo: angular.isUndefined($scope.orderNo) ? '' : $scope.orderNo,
                Customer: angular.isUndefined($scope.customer) ? '' : $scope.customer,
                From: angular.isUndefined($scope.orderDateFrom) ? '' : $scope.orderDateFrom.toDateString("yyyy-MM-dd"),
                To: angular.isUndefined($scope.orderDateTo) ? '' : $scope.orderDateTo.toDateString("yyyy-MM-dd"),
                SalesPerson: angular.isUndefined($scope.salesPerson) ? '' : $scope.salesPerson,
                Carrier: angular.isUndefined($scope.carrier) ? '' : $scope.carrier,
                Status: $scope.OrderStatus.value == 'Select Status' ? '' : $scope.OrderStatus.value
            };
            HandleSorting(grid,sortColumns);
        });
        gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
            paginationOptions.pageNumber = newPage;
            paginationOptions.pageSize = pageSize;
            var SearchCriteria = {
                OrderNo: angular.isUndefined($scope.orderNo) ? '' : $scope.orderNo,
                Customer: angular.isUndefined($scope.customer) ? '' : $scope.customer,
                From: angular.isUndefined($scope.orderDateFrom) ? '' : $scope.orderDateFrom.toDateString("yyyy-MM-dd"),
                To: angular.isUndefined($scope.orderDateTo) ? '' : $scope.orderDateTo.toDateString("yyyy-MM-dd"),
                SalesPerson: angular.isUndefined($scope.salesPerson) ? '' : $scope.salesPerson,
                Carrier: angular.isUndefined($scope.carrier) ? '' : $scope.carrier,
                Status: $scope.OrderStatus.value == 'Select Status' ? '' : $scope.OrderStatus.value
            };
            if (angular.isUndefined($scope.sortObject)) {
                getPage(SearchCriteria);
            }
            else {
                getPageBySort(SearchCriteria);
            }
            
        });

    };

    var HandleSorting = HandleSorting;
    function HandleSorting(grid,sortColumns){
         $scope.sortObject = appFactory.getSortObject(grid, sortColumns);
         var SearchCriteria = {
             OrderNo: angular.isUndefined($scope.orderNo) ? '' : $scope.orderNo,
             Customer: angular.isUndefined($scope.customer) ? '' : $scope.customer,
             From: angular.isUndefined($scope.orderDateFrom) ? '' : $scope.orderDateFrom.toDateString("yyyy-MM-dd"),
             To: angular.isUndefined($scope.orderDateTo) ? '' : $scope.orderDateTo.toDateString("yyyy-MM-dd"),
             SalesPerson: angular.isUndefined($scope.salesPerson) ? '' : $scope.salesPerson,
             Carrier: angular.isUndefined($scope.carrier) ? '' : $scope.carrier,
             Status: $scope.OrderStatus.value == 'Select Status' ? '' : $scope.OrderStatus.value
         };

         if (angular.isUndefined($scope.sortObject)) {
            $scope.sortObject = '';
         }
        if ($scope.sortObject == '') {
            getPage(SearchCriteria);
        }
        else {
            getPageBySort(SearchCriteria);
        }
    };
    var SearchCriteria = {
        OrderNo: angular.isUndefined($scope.orderNo) ? '' : $scope.orderNo,
        Customer: angular.isUndefined($scope.customer) ? '' : $scope.customer,
        From: angular.isUndefined($scope.orderDateFrom) ? '' : $scope.orderDateFrom.toDateString("yyyy-MM-dd"),
        To: angular.isUndefined($scope.orderDateTo) ? '' : $scope.orderDateTo.toDateString("yyyy-MM-dd"),
        SalesPerson: angular.isUndefined($scope.salesPerson) ? '' : $scope.salesPerson,
        Carrier: angular.isUndefined($scope.carrier) ? '' : $scope.carrier,
        Status: $scope.OrderStatus.value == 'Select Status' ? '' : $scope.OrderStatus.value
    };
     //function if filter and sorting is used
    var getPageBySort = getPageBySort;
    function getPageBySort(SearchCriteria) {
       
        SPAOrderService.searchBasedonSort(WebApiUrl, SearchCriteria.OrderNo, SearchCriteria.Customer, SearchCriteria.From, SearchCriteria.To, SearchCriteria.SalesPerson, SearchCriteria.Carrier, SearchCriteria.Status, $scope.sortObject)
        .then(function (data) {
            $scope.gridOptions.totalItems = data.length;
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);//displaying pagewise data

        })
        .catch(function (e) { $scope.error = resourceProvider.sortedOrderListError(); });
    };
    var getPage = getPage;
    function getPage(SearchCriteria) {
       //call to service to get data
        SPAOrderService.search(WebApiUrl,SearchCriteria.OrderNo,SearchCriteria.Customer,SearchCriteria.From,SearchCriteria.To,SearchCriteria.SalesPerson,SearchCriteria.Carrier,SearchCriteria.Status)
        .then(function (data) {
            
            $scope.gridOptions.totalItems = data.length;
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);//displaying pagewise data
        })        
        .catch(function (e) {
          
            $scope.error = resourceProvider.orderListError();;
        });
    };

    getPage(SearchCriteria);
    //intializing parameters for search, when search criteria is specified
    $scope.searchOrders =searchOrders;
    function searchOrders() {
        var SearchCriteria = {
            OrderNo: angular.isUndefined($scope.orderNo) ? '' : $scope.orderNo,
            Customer: angular.isUndefined($scope.customer) ? '' : $scope.customer,
            From: angular.isUndefined($scope.orderDateFrom) ? '' : $scope.orderDateFrom.toDateString("yyyy-MM-dd"),
            To: angular.isUndefined($scope.orderDateTo) ? '' : $scope.orderDateTo.toDateString("yyyy-MM-dd"),
            SalesPerson: angular.isUndefined($scope.salesPerson) ? '' : $scope.salesPerson,
            Carrier: angular.isUndefined($scope.carrier) ? '' : $scope.carrier,
            Status: $scope.OrderStatus.value == 'Select Status' ? '' : $scope.OrderStatus.value
        };
            if (angular.isUndefined($scope.sortObject)) {
                $scope.sortObject = '';
            }
            if ($scope.sortObject == '') {
                getPage(SearchCriteria);
            }
            else {
                getPageBySort(SearchCriteria);
            }

      
    };
   

};