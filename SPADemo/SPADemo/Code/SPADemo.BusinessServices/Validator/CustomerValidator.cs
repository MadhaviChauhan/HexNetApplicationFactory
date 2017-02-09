
using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Resource;
using SPADemo.Common.Extension;
using SPADemo.DataAccessInterface;
using FluentValidation;

namespace SPADemo.BusinessServices.Validator
{
    public class CustomerValidator : ValidatorBase<CustomerEntity>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            RuleFor(cust => cust.Name)
                .NotEmpty()
                .WithMessage(ConstructMessage(ValidationMessages.ResourceManager.GetString("FieldIsRequired"), "Customer Name"));

            RuleFor(cust => cust.Phone)
                .NotEmpty()
                .WithMessage(ConstructMessage(ValidationMessages.ResourceManager.GetString("FieldIsRequired"), "Customer Phone"));

            RuleFor(cust => cust.Email)
                .NotEmpty()
                .WithMessage(ConstructMessage(ValidationMessages.ResourceManager.GetString("FieldIsRequired"), "Customer Email"));

            //RuleFor(cust => cust.Email)
            //    .Must(NotAlreadyExist)
            //    .WithMessage(ConstructMessage(ValidationMessages.DuplicateError, "Customer"));

        }

        private bool NotAlreadyExist(CustomerEntity entity, string email)
        {
            //var criteria = ParameterHelper.New()
            //    .Add(Parameter<Customer>.Add(o => o.Email, email));

            //var duplicates = _customerRepository.GetBy(criteria).Where(x => x.Email != entity.Email);

            return false;//duplicates.Any();
        }

    }
}
