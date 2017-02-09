using SPADemo.BusinessEntities;
using SPADemo.DataAccessInterface.Repository;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace SPADemo.Data.Test
{
    [TestFixture]
    internal class Testing_Data_Using_UOW : DataAccessBaseFixture
    {
        int _newCustomerId = 0;
        int _newProductId = 0;
        int _newOrderId = 0;
        [SetUp]
        public void SetUp()
        {
            string sqlString = @"INSERT INTO Customer(Name, Address, Phone,Email) VALUES ('Jimy Ket', 'New Yeark', '1234567890','Jimyket@hexnet.com');SELECT SCOPE_IDENTITY()";
            _newCustomerId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO Product (Name, IsInStock, Quantity) VALUES ('Mouse', 1, 100);SELECT SCOPE_IDENTITY()";
            _newProductId = SQLOperation(sqlString);

            sqlString = @"INSERT INTO [dbo].[Order] (CustomerID, OrderDate) VALUES (" + _newCustomerId + ", GETDATE());SELECT SCOPE_IDENTITY()";
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
        }
        [Test]
        public void can_get_all_customer_data_with_CustomerRepository_through_UOW()
        {
            using (var uow = container.Resolve<IUnitOfWork>())
            {
                var list = uow.CustomerRepository.GetAll();
                list.Count().ShouldBeGreaterThan(0);
            }
        }
        [Test]
        public void can_create_a_new_customer_with_CustomerRepository_through_UOW()
        {

            var newbie = new CustomerEntity()
            {
                Name = "James Bob ",
                Phone = "66666666",
                Address = "New yark City",
                Email = "Jamesbob@hexnet.com"
            };

            using (var uow = container.Resolve<IUnitOfWork>())
            {
                uow.CustomerRepository.Save(newbie);
                uow.Commit();

                var existingCustomer = uow.CustomerRepository.GetById(newbie.Id);
                existingCustomer.Name.ShouldBe(newbie.Name);
                existingCustomer.Address.ShouldBe(newbie.Address);
                existingCustomer.Phone.ShouldBe(newbie.Phone);
                existingCustomer.Email.ShouldBe(newbie.Email);
            }
        }

        [Test]
        public void can_delete_a_customer_with_CustomerRepository_through_UOW()
        {
            var newbie = new CustomerEntity()
            {
                Name = "James Bob ",
                Phone = "66666666",
                Address = "New yark City",
                Email = "Jamesbob@hexnet.com"
            };

            using (var uow = container.Resolve<IUnitOfWork>())
            {
                uow.CustomerRepository.Save(newbie); //to save Customer to Save delete test
                uow.Commit();

                uow.CustomerRepository.Delete(newbie.Id);
                uow.Commit();

                var existingCustomer = uow.CustomerRepository.GetById(newbie.Id);
                Assert.AreEqual(existingCustomer, null);
            }
        }
        [Test]
        public void can_update_customer_with_CustomerRepository_through_UOW()
        {

            var cust = new CustomerEntity()
            {
                Id = _newCustomerId,
                Name = "Bob Jimy",
                Phone = "1919191913",
                Address = "New Yark City",
                Email = "bobjimy@hexnet.com"
            };
            using (var uow = container.Resolve<IUnitOfWork>())
            {
                uow.CustomerRepository.Save(cust);
                uow.Commit();

                CustomerEntity updatedCustomer = uow.CustomerRepository.GetById(_newCustomerId);
                updatedCustomer.Name.ShouldBe(cust.Name);
                updatedCustomer.Address.ShouldBe(cust.Address);
                updatedCustomer.Phone.ShouldBe(cust.Phone);
                updatedCustomer.Email.ShouldBe(cust.Email);
            }
        }


        [Test]
        public void can_get_data_based_on_id_with_CustomerRepository_through_UOW()
        {

            int id = _newCustomerId;
            using (var uow = container.Resolve<IUnitOfWork>())
            {
                var customer = uow.CustomerRepository.GetById(id);
                customer.Id.ShouldBe(id);
            }
        }

        [Test]
        public void can_get_attributes_mapped_with_UOW()
        {
            using (var uow = container.Resolve<IUnitOfWork>())
            {
                var customer = uow.CustomerRepository.GetAll().ToList();
                customer[0].Name.ShouldNotBeEmpty();
                customer[0].Id.ShouldBeGreaterThan(0);
            }
        }



        [Test]
        public void can_rollback_customer_Using_UOW()
        {
            var newbie = new CustomerEntity()
            {
                Name = "Customer ",
                Phone = "66666666",
                Address = "New Mumbai Address"
            };
            using (var uow = container.Resolve<IUnitOfWork>())
            {
                uow.CustomerRepository.Save(newbie);
                uow.Rollback();

                var existingCustomer = uow.CustomerRepository.GetById(newbie.Id);
                Assert.AreEqual(existingCustomer, null);
            }
        }
    }
}
