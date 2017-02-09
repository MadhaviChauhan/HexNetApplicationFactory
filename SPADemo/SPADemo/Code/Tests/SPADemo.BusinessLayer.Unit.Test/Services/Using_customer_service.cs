using SPADemo.BusinessEntities;
using SPADemo.BusinessServices;
using SPADemo.DataAccessInterface;
using SPADemo.DataAccessInterface.Repository;
using FluentValidation;
using NSubstitute;
using SPADemo.TestFramework;

namespace SPADemo.BusinessLayer.Unit.Test.Services
{
    public abstract class Using_customer_service : SpecFor<CustomerService>
    {
        protected IValidator<CustomerEntity> CustomerValidator;
        protected IUnitOfWork UnitOfWork;
        protected ICustomerRepository CustomerRepository;

        public override void Context()
        {
            CustomerValidator = Substitute.For<IValidator<CustomerEntity>>();
            UnitOfWork = Substitute.For<IUnitOfWork>();
            CustomerRepository = Substitute.For<ICustomerRepository>();
            UnitOfWork.CustomerRepository.Returns(CustomerRepository);
            subject = new CustomerService(CustomerValidator, UnitOfWork);
        }
    }
}
