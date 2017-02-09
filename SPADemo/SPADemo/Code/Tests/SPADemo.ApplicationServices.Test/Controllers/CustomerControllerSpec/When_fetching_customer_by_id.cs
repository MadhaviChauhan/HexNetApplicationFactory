using SPADemo.BusinessEntities;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System.Web.Http;
using System.Web.Http.Results;

namespace SPADemo.ApplicationServices.Test.Controllers.CustomerControllerSpec
{
    class When_fetching_customer_by_id : Using_customer_controller
    {
        private int _id = 1;
        private IHttpActionResult _result;
        private CustomerEntity _customer;

        public override void Context()
        {
            base.Context();
            _customer = new CustomerEntity()
            {
                Id = _id,
                Name = "test"
            };
            CustomerService.GetCustomerById(_id).Returns(_customer);
        }

        public override void Because()
        {
            _result = subject.GetCustomerById(_id);
        }

        [Test]
        public void call_is_made_to_business_service_to_fetch_customer()
        {
            CustomerService.Received(1).GetCustomerById(_id);
        }

        [Test]
        public void appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<OkNegotiatedContentResult<CustomerEntity>>();
            var castedResult = _result as OkNegotiatedContentResult<CustomerEntity>;
            castedResult.ShouldNotBe(null);
            castedResult.Content.Id.ShouldBe(_customer.Id);
            castedResult.Content.Name.ShouldBe(_customer.Name);
        }

    }
}
