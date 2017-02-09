//to create culture specific messages refer :http://jsfiddle.net/4tRBY/41/

app.provider('resourceProvider', function() {  

    this.$get = function() {
        
        return {
            getCustomersError: function() {
                return  "ERROR GETTING CUSTOMER LIST";
            },
            getFilterCustomersError: function() {
                return  "ERROR GETTING FILTERED CUSTOMER LIST";
            },
            createCustomerError: function () {
                return "ERROR CREATING CUSTOMER";
            },
             createCustomerSuccess: function () {
                return "CUSTOMER CREATED SUCCESSFULLY";
            },
             editCustomerError: function () {
                return "ERROR EDITING CUSTOMER";
            },
             editCustomerSuccess: function () {
                return "CUSTOMER UPDATED SUCCESSFULLY";
            }, 
            deleteCustomerError: function () {
                return "ERROR DELETING CUSTOMER";
            },
            deleteCustomerSuccess: function () {
                return "CUSTOMER DELETED SUCCESSFULLY";
            },
            getCustomerError: function () {
                return "ERROR GETTING CUSTOMER";
            },
            sortedOrderListError: function () {
                return "ERROR GETTING SORTED ORDER LIST";
            },
            orderListError: function () {
                return "ERROR GETTING ORDER LIST";
            },
            orderDetailError: function () {
                return "ERROR GETTING ORDER DETAILS";
            },
            productDetailError: function () {
                return "ERROR GETTING PRODUCT DETAILS";
            }
        }
    };

});
