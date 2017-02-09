using SPADemo.BusinessEntities;
using SPADemo.DataAccessInterface;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace SPADemo.Data.Test
{
    /// <summary>
    /// Testing_Customer_Data_Dapper: This is for Nunit test cases  
    /// </summary>
    [TestFixture]
    internal class Testing_Data_Using_Repository : DataAccessBaseFixture
    {
        int _newCustomerId = 0;
        int _newProductId = 0;
        int _newOrderId = 0;
        int _newRegionId = 0;
        [SetUp]
        public void SetUp()
        {

            string sqlString = @"INSERT INTO Customer(Name, Address, Phone,Email) VALUES ('Jimy Ket', 'Test Address', '1234567890','Jumyket@hexnet.com');SELECT SCOPE_IDENTITY()";
            _newCustomerId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO Region (Name) VALUES ('Missouri');;SELECT SCOPE_IDENTITY()";
            _newRegionId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO Product (Name, IsInStock, Quantity) VALUES ('Mouse', 1, 100);SELECT SCOPE_IDENTITY()";
            _newProductId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO [dbo].[Order] (CustomerID, OrderDate,RegionID) VALUES (" + _newCustomerId + ", GETDATE()," + _newRegionId + ");SELECT SCOPE_IDENTITY()";
            _newOrderId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO [dbo].[OrderDetail] (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES (" + _newOrderId + ", " + _newProductId + ", 10, 299.50,0);SELECT SCOPE_IDENTITY()";
            SQLOperation(sqlString);
        }

        [TearDown]
        public void CleanUp()
        {
            string sqlString = @"Delete from [OrderDetail] ";
            SQLOperation(sqlString);

            sqlString = @"Delete from [Order] ";
            SQLOperation(sqlString);


            sqlString = @"Delete from Product ";
            SQLOperation(sqlString);

            sqlString = @"Delete from  Customer";
            SQLOperation(sqlString);

            sqlString = @"Delete from  Region";
            SQLOperation(sqlString);
        }

        [Test]
        public void can_get_all_customer_data_with_CustomerRepository()
        {
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                var list = customerRepository.GetAll();
                list.Count().ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void can_get_regional_sales_data()
        {
            using (IRegionRepository regionRepository = container.Resolve<IRegionRepository>())
            {
                var list = regionRepository.GetRegionalSales();
                list.Count().ShouldBeGreaterThan(0);
            }
        }
        [Test]
        public void can_create_a_new_customer_with_CustomerRepository()
        {

            var newbie = new CustomerEntity()
            {
                Name = "James Bob",
                Phone = "66666666",
                Address = "New Yark City",
                Email = "Jamesbob@hexnet.com"
            };
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                customerRepository.Save(newbie);
                var existingCustomer = customerRepository.GetById(newbie.Id);
                existingCustomer.Name.ShouldBe(newbie.Name);
                existingCustomer.Address.ShouldBe(newbie.Address);
                existingCustomer.Phone.ShouldBe(newbie.Phone);
                existingCustomer.Email.ShouldBe(newbie.Email);
            }
        }

        [Test]
        public void can_delete_a_customer_with_CustomerRepository()
        {
            var newbie = new CustomerEntity()
            {
                Name = "James Bob",
                Phone = "66666666",
                Address = "New Yark City",
                Email = "Jamesbob@hexnet.com"
            };
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                customerRepository.Save(newbie);//to Save new Customer for delete

                customerRepository.Delete(newbie.Id);
                var existingCustomer = customerRepository.GetById(newbie.Id);
                Assert.AreEqual(existingCustomer, null);
            }
        }
        [Test]
        public void can_update_customer_with_CustomerRepository()
        {

            var cust = new CustomerEntity()
            {
                Id = _newCustomerId,
                Name = "Bob James",
                Phone = "1919191913",
                Address = "New Yark City",
                Email = "Jamesbob@hexnet.com"
            };
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                customerRepository.Save(cust);

                CustomerEntity updatedCustomer = customerRepository.GetById(_newCustomerId);
                updatedCustomer.Name.ShouldBe(cust.Name);
                updatedCustomer.Address.ShouldBe(cust.Address);
                updatedCustomer.Phone.ShouldBe(cust.Phone);
            }
        }
        [Test]

        public void can_get_data_based_on_id_with_CustomerRepository()
        {

            int id = _newCustomerId;
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                var customer = customerRepository.GetById(id);
                customer.Id.ShouldBe(id);
            }
        }


        [Test]
        public void can_get_attributes_mapped_with_CustomerRepository()
        {
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                var customer = customerRepository.GetAll().ToList();
                customer[0].Name.ShouldNotBeEmpty();
                customer[0].Id.ShouldBeGreaterThan(0);
            }
        }


    }
}
