using SPADemo.BusinessEntities;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;

namespace SPADemo.BusinessLayer.Unit.Test.Services
{
    class When_saving_customer_fails_on_exception : Using_customer_service
    {
        private CustomerEntity _customer;
        private Exception _configuredException;
        private Exception _thrownException;

        public override void Context()
        {
            base.Context();
            _customer = new CustomerEntity();
            _configuredException = new Exception("test");
            CustomerRepository.When(o => { o.Save(Arg.Any<CustomerEntity>()); })
                .Do(o => { throw _configuredException; });
        }

        public override void Because()
        {
            try
            {
                subject.SaveCustomer(_customer);
            }
            catch (Exception ex)
            {
                _thrownException = ex;
            }
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
        public void call_is_made_to_unit_of_work_to_rollback_transaction()
        {
            UnitOfWork.Received(1).Rollback();
        }

        [Test]
        public void appropriate_exception_is_thrown()
        {
            _thrownException.ShouldNotBe(null);
            _thrownException.ShouldBe(_configuredException);
        }
    }
}
