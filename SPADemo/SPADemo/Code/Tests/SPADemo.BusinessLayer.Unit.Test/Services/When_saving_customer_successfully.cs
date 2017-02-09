using SPADemo.BusinessEntities;
using NSubstitute;
using NUnit.Framework;

namespace SPADemo.BusinessLayer.Unit.Test.Services
{
    class When_saving_customer_successfully : Using_customer_service
    {
        private CustomerEntity _customer;

        public override void Context()
        {
            base.Context();
            _customer = new CustomerEntity();
        }

        public override void Because()
        {
            subject.SaveCustomer(_customer);
        }

        [Test]
        public void call_is_made_to_validator_to_validate_customer_object()
        {
            CustomerValidator.Received(1).Validate(_customer);
        }

        [Test]
        public void call_is_made_to_save_customer_object()
        {
            CustomerRepository.Received(1).Save(_customer);
        }

        [Test]
        public void call_is_made_to_unit_of_work_to_commit_transaction()
        {
            UnitOfWork.Received(1).Commit();
        }

    }
}
