using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Interface;
using Caching.Interface;
using SPADemo.Common.Attributes;
using SPADemo.DataAccessInterface.Repository;
using FluentValidation;
using System.Collections.Generic;
namespace SPADemo.BusinessServices
{
    public class CustomerService : ICustomerService, ICacheable
    {
        private const string CustomerCacheDependencyKey = "CustomerService.BusinessEntities.Customer";
        private readonly IValidator<CustomerEntity> _customerValidator;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IValidator<CustomerEntity> customerValidator,
            IUnitOfWork unitOfWork)
        {
            _customerValidator = customerValidator;
            _unitOfWork = unitOfWork;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            return customer;
        }

        //Here caching used for reference, dont use caching for transactional data
        [Cacheable(CacheableAttribute.CacheBehavior.Add, CustomerCacheDependencyKey)]
        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customer = _unitOfWork.CustomerRepository.GetAll();
            return customer;
        }


        public IEnumerable<CustomerEntity> GetCustomersByFilter(string filterObject, string sortObject)
        {
            var customer = _unitOfWork.CustomerRepository.GetCustomersByFilter(filterObject, sortObject);
            return customer;
        }
        [Cacheable(CacheableAttribute.CacheBehavior.Remove, CustomerCacheDependencyKey)]
        public void SaveCustomer(CustomerEntity customer)
        {
            _customerValidator.Validate(customer);
            try
            {
                _unitOfWork.CustomerRepository.Save(customer);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
        [Cacheable(CacheableAttribute.CacheBehavior.Remove, CustomerCacheDependencyKey)]
        public void DeleteCustomer(int id)
        {
            try
            {
                _unitOfWork.CustomerRepository.Delete(id);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
