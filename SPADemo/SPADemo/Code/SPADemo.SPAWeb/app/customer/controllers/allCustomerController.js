
//controller intialization to display all the customers
appcustomer.controller('allCustomerController', allCustomerController);

allCustomerController.$inject=['$scope','$rootScope','$uibModal','SPACRUDService','appFactory','uiGridConstants','WebApiUrl','resourceProvider'];
function allCustomerController($scope,$rootScope, $uibModal, SPACRUDService,appFactory, uiGridConstants,WebApiUrl ,resourceProvider) {
  
   $scope.Customers = [];
  
    //code for reloading a content of grid when modalInstance is closed for create customer
   $rootScope.$on('ReloadGrid', function (event) { getPage();});
   
   //paginatin options for ui-grid
    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };
    //function if filter and sorting is used
    var getPageByFilter = getPageByFilter;
    function getPageByFilter() {

        SPACRUDService.getCustomersByFilter(WebApiUrl, $scope.filterObject, $scope.sortObject)
        .then(function (data) {
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.Customers = data.slice(firstRow, firstRow + paginationOptions.pageSize);
            $scope.gridOptions.totalItems = data.length;
           
        })
        .catch(function(e){$scope.error = resourceProvider.getFilterCustomersError();})
        ;;
    };
    //function to call getcustomers service function to load the data
    var getPage = getPage;
    function getPage() {


        SPACRUDService.getCustomers(WebApiUrl)
        .then(function (data) {
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.Customers = data.slice(firstRow, firstRow + paginationOptions.pageSize);
            $scope.gridOptions.totalItems = data.length;
           
           
        })
        .catch(function(e){$scope.error = resourceProvider.getCustomersError();})
        ;
    };
    function displayMessage(message)
    {
        $rootScope.message = message;
    }
    //function gets called when the view for the controller is loading
    getPage();
    //grid data intialization
    $scope.gridOptions = {
        data: 'Customers',
        multiSelect: false,
        paginationPageSizes: [25,50,75,100,200,300,400, 500,600,700,800,900, 1000],//drop down for no. of items per page in grid
        paginationPageSize: 25,
        useExternalPagination: true,enableColumnResizing: true,
        useExternalSorting: true,
        enableFiltering: true,useExternalFiltering:true, //to filter content of grid per page
        enableSelectAll: false, enableRowSelection: true, noUnselect: true, enableRowHeaderSelection: false,
        columnDefs: [{ field: 'Id', displayName: 'Customer ID', enableFiltering: false},
            { field: 'Name', displayName: 'Customer Name'},
         { field: 'Address', displayName: 'Address' }, { field: 'Phone', displayName: 'Phone', enableFiltering: false},
         { field: 'Email', displayName: 'Email' },
         {field:'Action',enableColumnMenu:false,enableFiltering:false,displayName:'',cellTemplate:'<div style="text-align: center;"><button type="button" class="btn btn-sm btn-primary" ng-click="grid.appScope.edit(row)">Edit</button></div>'},
         {field:'Action',enableColumnMenu:false,enableFiltering:false,displayName:'',cellTemplate:'<div style="text-align: center;"><button type="button" class="btn btn-sm btn-primary" ng-click="grid.appScope.view(row)">Details</button></div>'},
         {field:'Action',enableColumnMenu:false,enableFiltering:false,displayName:'',cellTemplate:'<div style="text-align: center;"><button type="button" class="btn btn-sm btn-primary" ng-click="grid.appScope.delete(row)">Delete</button></div>'}]
         //{ field: 'Action', enableColumnMenu: false, enableFiltering: false, displayName: '', cellTemplate: '<div><a href="#editCustomerView/{{row.entity.ID}}/{{row.entity.Name}}/{{row.entity.Address}}/{{row.entity.Phone}}/{{row.entity.Email}}">Edit</a></div>' },
         //{ field: 'Action', enableColumnMenu: false, enableFiltering: false, displayName: '', cellTemplate: '<div><a href="#singleCustomerView/{{row.entity.ID}}">Details</a></div>' },
         //{ field: 'Action', enableColumnMenu: false, enableFiltering: false, displayName: '', cellTemplate: '<div><a href="#deleteCustomerView/{{row.entity.ID}}">Delete</a></div>' }]

    };
   
    //to open create customer dialog
    $scope.create = createCustomerView;
    function createCustomerView() {
        
        var modalInstance = $uibModal.open({
            //templateUrl: 'editCustomerView/' + row.entity.ID + '/' + row.entity.Name + '/' + row.entity.Address + '/' + row.entity.Phone + '/' + row.entity.Email,
            templateUrl: 'customer/views/createCustomerView.html',
            controller: 'createCustomerController'  
        });
        modalInstance.result.then(function () { displayMessage(resourceProvider.createCustomerSuccess()); });
        
    };
   
   //to opern edit customer dialog
    $scope.edit=editCustomerView;
    function editCustomerView(row){
        var modalInstance =  $uibModal.open({
        templateUrl: 'customer/views/editCustomerView.html',
        controller: 'editCustomerController',
        resolve: {
            routeParams: function () {
                return row;
            }
        }
        });
        //once dialog is closed reload the grid by calling getPage function
        modalInstance.result.then(function () { getPage(); displayMessage(resourceProvider.editCustomerSuccess()); });
         
    };

    //to open single customer view dialog
    $scope.view=singleCustomerView;
    function singleCustomerView(row) {
        $rootScope.message = undefined;
        var modalInstance =  $uibModal.open({
            
            templateUrl: 'customer/views/singleCustomerView.html',
           
            controller: 'singleCustomerController',
            resolve: {
                routeParams: function () {
                    return row;
                }
            }
        });       

    };
    //to open delete customer dialog
    $scope.delete=deleteView;
    function deleteView(row){
        var modalInstance =  $uibModal.open({
            
            templateUrl: 'customer/views/deleteCustomerView.html',
            controller: 'deleteCustomerController',
            resolve: {
                routeParams: function () {
                    return row;
                }
            }
        });

        modalInstance.result.then(function () { getPage(); displayMessage(resourceProvider.deleteCustomerSuccess()); });
        
    };

    
    //to register api for select and pageination events on grid
    $scope.gridOptions.onRegisterApi = registerGridApi;
    function registerGridApi(gridApi) {
        
        //set gridApi on scope
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            var msg = row.entity.ID;
           
        });
        //handling filter event
        gridApi.core.on.filterChanged($scope, function () {
      
            HandleFiltering(this.grid.columns);
            $rootScope.message = undefined;
        });
        //handling sorting
        gridApi.core.on.sortChanged($scope,function(grid,sortColumns){
            HandleSorting(grid, sortColumns);
            $rootScope.message = undefined;
        });
       //handle paging event
        gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
            paginationOptions.pageNumber = newPage;
            paginationOptions.pageSize = pageSize;
            
            if (angular.isUndefined($scope.filterObject)) {
           $scope.filterObject = '';
               }
               if (angular.isUndefined($scope.sortObject)) {
                   $scope.sortObject = '';
               }
               if (($scope.filterObject == '') && ($scope.sortObject == '')) {
                   getPage();
               }
                else {
           
                    getPageByFilter();
               }
               $rootScope.message = undefined;
        });
       
       
    };
   
  
    
   //function to create sort object
   var HandleSorting=HandleSorting;
   function HandleSorting(grid,sortColumns){
      
       $scope.sortObject = appFactory.getSortObject(grid, sortColumns);
       if (angular.isUndefined($scope.filterObject)) {
           $scope.filterObject = '';
       }
       if (angular.isUndefined($scope.sortObject)) {
           $scope.sortObject = '';
       }
       if (($scope.filterObject == '') && ($scope.sortObject == '')) {
           getPage();
       }
        else {
           
            getPageByFilter();
        }
   };
    //function to create filter object
   var HandleFiltering = HandleFiltering;
   
   function HandleFiltering(gridColumns) {
     
       $scope.filterObject = appFactory.getFilterObject(gridColumns);
       if (angular.isUndefined($scope.filterObject)) {
           $scope.filterObject = '';
       }
       if (angular.isUndefined($scope.sortObject)) {
           $scope.sortObject = '';
       }
       if (($scope.filterObject == '') && ($scope.sortObject == '')) {
           getPage();
       }
       else {
         
           getPageByFilter();
       }
   };

  
  

   
};  