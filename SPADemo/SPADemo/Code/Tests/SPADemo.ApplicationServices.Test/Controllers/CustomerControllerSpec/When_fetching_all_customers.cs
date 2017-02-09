using SPADemo.BusinessEntities;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace SPADemo.ApplicationServices.Test.Controllers.CustomerControllerSpec
{
    class When_fetching_all_customers : Using_customer_controller
    {
        private IEnumerable<CustomerEntity> _result;
        private List<CustomerEntity> _customers;
        private CustomerEntity _customer1;
        private CustomerEntity _customer2;


        public override void Context()
        {
            base.Context();
            _customer1 = new CustomerEntity() { Name = "test1" };
            _customer2 = new CustomerEntity() { Name = "test2" };
            _customers = new List<CustomerEntity>() { _customer1, _customer2 };
            CustomerService.GetCustomers().Returns(_customers);
        }

        public override void Because()
        {
            _result = subject.GetCustomers();
        }

        [Test]
        public void call_is_made_to_business_service_to_fetch_data()
        {
            CustomerService.Received(1).GetCustomers();
        }

        [Test]
        public void appropriate_result_is_returned()
        {
            _result.ShouldNotBe(null);
            _result.ShouldBe(_customers);
            _result.Count().ShouldBe(2);
        }
    }
}