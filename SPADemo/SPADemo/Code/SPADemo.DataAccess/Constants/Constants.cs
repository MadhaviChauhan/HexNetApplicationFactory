namespace SPADemo.DataAccess.Constants
{
    internal class StoreProcedureConstants
    {
        public const string spGetAllCustomer = "CustomerGetAll";
        public const string spGetCustomersByFilter = "CustomerGetByFilter";
        public const string spGetCustomerByID = "CustomerGetByID";
        public const string spUpdateCustomer = "CustomerUpdate";
        public const string spInsertCustomer = "CustomerInsert";
        public const string spDeleteCustomer = "CustomerDelete";


        public const string spGetCustomerBy = "CustomerGetByFilter";
        public const string spGetOrderByFilter = "OrderGetByFilter";
        public const string spGetOrderBySort = "OrderGetBySort";
        public const string spGetOrderDetailByOrderNo = "OrderDetailGetByOrderNo";
        public const string spGetOrderProductByOrderNo = "OrderProductGetByOrderNo";

        public const string spGetRegionalSales = "RegionGetSales";

        public const string spGetAllProducts = "ProductGetAll";
        public const string spGetProductByID = "ProductGetByID";
        public const string spUpdateProduct = "ProductUpdate";
        public const string spInsertProduct = "ProductInsert";
        public const string spDeleteProduct = "ProductDelete";

    }
}