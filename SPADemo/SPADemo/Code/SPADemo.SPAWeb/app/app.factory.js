
//common functionality for customer module
app.factory("appFactory", function ($http){
   
    return{
        getSortObject: function(grid,sortColumns) {
            var sortObject = undefined;
            var sortOrder = [];
           
            for (var i = 0; i < sortColumns.length; i++)
            {
                sortOrder.push({ field: sortColumns[i].field, order: sortColumns[i].sort.direction });
            }
            
          
            for (var i = 0; i < sortOrder.length; i++) {
                if (angular.isUndefined(sortObject)) {
                    sortObject = sortOrder[i].field + ' ' + sortOrder[i].order;
                }
                else
                {
                    sortObject = sortObject + ',' + sortOrder[i].field + ' ' + sortOrder[i].order;
                }
            }

            return sortObject;
        
        }       ,
        getFilterObject : function (gridColumns) {
            var filterObject = undefined;
            var filter = [];

            for (var i = 0; i < gridColumns.length; i++) {
                if (!(angular.isUndefined(gridColumns[i].filters[0].term)) && gridColumns[i].filters[0].term != null) {
                    filter.push({ field: gridColumns[i].field, term: gridColumns[i].filters[0].term });
                }
            }
            for (var i = 0; i < filter.length; i++) {
                if (angular.isUndefined(filterObject)) {
                    filterObject = filter[i].field + " Like '%" + filter[i].term + "%'";
                }
                else {
                    filterObject = filterObject + ' AND ' + filter[i].field + " Like '%" + filter[i].term + "%'";
                }
            }
            return filterObject;
        },
       
        getWebApiUrl: function () {
            var jsonData = $http.get('../../config/config.json');
           
            return jsonData;
        }



    }
});

