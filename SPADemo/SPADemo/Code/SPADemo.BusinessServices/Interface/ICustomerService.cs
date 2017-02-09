using SPADemo.BusinessEntities;
using System.Collections.Generic;

namespace SPADemo.BusinessServices.Interface
{
    public interface ICustomerService
    {
        IEnumerable<CustomerEntity> GetCustomers();
        IEnumerable<CustomerEntity> GetCustomersByFilter(string filterObject, string sortObject);
        CustomerEntity GetCustomerById(int id);

        void SaveCustomer(CustomerEntity customer);
        void DeleteCustomer(int id);
    }
}
