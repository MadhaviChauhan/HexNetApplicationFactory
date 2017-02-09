using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Interface;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SPADemo.ApplicationServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegionController : ApiController
    {
        IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public IEnumerable<OrderEntity> GetRegionalSales()

        {
            return (_regionService.GetRegionalSales()) as IEnumerable<OrderEntity>;
        }
    }
}