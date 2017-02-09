using SPADemo.BusinessEntities;
using SPADemo.DataAccessInterface.Repository;
using System.Collections.Generic;
namespace SPADemo.DataAccessInterface
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        IEnumerable<CustomerEntity> GetCustomersByFilter(string filterObject, string sortObject);
    }
}
