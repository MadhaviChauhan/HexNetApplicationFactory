using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Validator;
using NUnit.Framework;
using Russell.IPC.Test.Utilities.Validator;
using SPADemo.TestFramework;

namespace SPADemo.BusinessLayer.Unit.Test.Validators
{
    class When_validating_customer : SpecFor<CustomerValidator>
    {
        private CustomerEntity _customer;

        public override void Context()
        {
            _customer = new CustomerEntity()
            {
                Name = "test",
                Address = "test",
                Id = 1,
                Email = "test@test.com",
                Phone = "1234456789"
            };
            subject = new CustomerValidator(null);
        }

        public override void Because()
        {

        }

        [Test]
        public void should_have_error_when_name_is_empty()
        {
            _customer.Name = "";
            subject.ShouldThrowAndHaveValidationErrorFor(o => o.Name, _customer);
        }

        [Test]
        public void should_have_error_when_email_is_empty()
        {
            _customer.Email = "";
            subject.ShouldThrowAndHaveValidationErrorFor(o => o.Email, _customer);
        }

        [Test]
        public void should_have_error_when_phone_is_empty()
        {
            _customer.Phone = "";
            subject.ShouldThrowAndHaveValidationErrorFor(o => o.Phone, _customer);
        }

        [Test]
        public void should_not_have_any_error_for_valid_customer_object()
        {
            subject.Validate(_customer);
        }

    }
}
