using SPADemo.DataAccessInterface;
using SPADemo.DataAccessInterface.Repository;
using NUnit.Framework;

namespace SPADemo.Data.Test
{
    [TestFixture]
    class Testing_Class_Instance : DataAccessBaseFixture
    {
        [Test]
        public void can_container_resolve_UOW_class_instance()
        {
            using (IUnitOfWork uow = container.Resolve<IUnitOfWork>())
            {
                Assert.NotNull(uow);
            }
        }
        [Test]
        public void can_container_resolve_CustomerRepository_class_instance()
        {
            using (ICustomerRepository customerRepository = container.Resolve<ICustomerRepository>())
            {
                Assert.NotNull(customerRepository);
            }
        }

        [Test]
        public void can_container_resolve_CustomerRepository_class_instance_from_UOW()
        {

            using (var uow = container.Resolve<IUnitOfWork>())
            {
                ICustomerRepository customerRepository = uow.CustomerRepository;
                Assert.NotNull(customerRepository);
            }
        }
        [Test]
        public void can_container_resolve_OrderRepository_class_instance()
        {
            using (IOrderRepository orderRepository = container.Resolve<IOrderRepository>())
            {
                Assert.NotNull(orderRepository);
            }
        }
        [Test]
        public void can_container_resolve_OrderRepository_class_instance_from_UOW()
        {
            using (IUnitOfWork uow = container.Resolve<IUnitOfWork>())
            {
                IOrderRepository orderRepository = uow.OrderRepository;
                Assert.NotNull(orderRepository);
            }
        }

    }
}
