using SPADemo.BusinessEntities;
using SPADemo.Common.CustomException;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Shouldly;
using System;

namespace SPADemo.BusinessLayer.Unit.Test.Services
{
    class When_saving_customer_fails_validation : Using_customer_service
    {
        private CustomerEntity _customer;
        private RulesViolationException _configuredException;
        private Exception _thrownException;
        public override void Context()
        {
            base.Context();
            _customer = new CustomerEntity();
            _configuredException = new RulesViolationException("test");
            CustomerValidator.Validate(_customer).Throws(_configuredException);
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
        public void call_is_not_made_to_save_customer_object()
        {
            CustomerRepository.DidNotReceive().Save(Arg.Any<CustomerEntity>());
        }

        [Test]
        public void appropriate_exception_is_thrown()
        {
            _thrownException.ShouldNotBe(null);
            _thrownException.ShouldBeOfType<RulesViolationException>();
            _thrownException.ShouldBe(_configuredException);
        }
    }
}
