using SPADemo.ApplicationServices.Controllers;
using SPADemo.BusinessServices.Interface;
using NSubstitute;
using SPADemo.TestFramework;

namespace SPADemo.ApplicationServices.Test.Controllers.CustomerControllerSpec
{
    public abstract class Using_customer_controller : SpecFor<CustomerController>
    {
        protected ICustomerService CustomerService;

        public override void Context()
        {
            CustomerService = Substitute.For<ICustomerService>();
            subject = new CustomerController(CustomerService);
        }
    }
}
