using SPADemo.BusinessEntities;
using System.Collections.Generic;

namespace SPADemo.BusinessServices.Interface
{
    public interface IRegionService
    {
        IEnumerable<OrderEntity> GetRegionalSales();
    }
}
