using SPADemo.BusinessEntities;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace SPADemo.ApplicationServices.Test.Controllers.CustomerControllerSpec
{
    class When_getting_customer_by_filter : Using_customer_controller
    {
        private string _sortObject = "testSortObject";
        private string _filterObject = "testFilterObject";
        private List<CustomerEntity> _customers;
        private IEnumerable<CustomerEntity> _result;

        public override void Context()
        {
            base.Context();
            _customers = new List<CustomerEntity>() { new CustomerEntity(), new CustomerEntity() };
            CustomerService.GetCustomersByFilter(_filterObject, _sortObject).Returns(_customers);
        }

        public override void Because()
        {
            _result = subject.GetCustomersByFilter(_filterObject, _sortObject);
        }

        [Test]
        public void call_is_made_to_business_service_to_fetch_data()
        {
            CustomerService.Received(1).GetCustomersByFilter(_filterObject, _sortObject);
        }

        [Test]
        public void appropriate_result_is_received()
        {
            _result.ShouldNotBeNull();
            _result.ShouldBe(_customers);
        }
    }
}
