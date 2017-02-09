using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Interface;
using SPADemo.DataAccessInterface;
using System.Collections.Generic;

namespace SPADemo.BusinessServices
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;

        }

        public IEnumerable<OrderEntity> GetRegionalSales()
        {
            return _regionRepository.GetRegionalSales();
        }
    }
}
