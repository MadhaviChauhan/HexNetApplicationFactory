using SPADemo.BusinessEntities;
using SPADemo.DataAccessInterface.Repository;
using System.Collections.Generic;

namespace SPADemo.DataAccessInterface
{
    public interface IRegionRepository : IRepository<RegionEntity>
    {
        IEnumerable<OrderEntity> GetRegionalSales();
    }
}
