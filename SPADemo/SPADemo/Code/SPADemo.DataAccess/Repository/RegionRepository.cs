using SPADemo.BusinessEntities;
using SPADemo.DataAccess.Constants;
using SPADemo.DataAccess.Context;
using SPADemo.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace SPADemo.DataAccess.Repository
{
    public class RegionRepository : BaseRepository<DapperContext>, IRegionRepository
    {
        private DapperContext _dataContext;
        public RegionRepository(DapperContext dbContext)
            : base(dbContext)
        {
            _dataContext = dbContext;
        }
        public IEnumerable<SPADemo.BusinessEntities.RegionEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public BusinessEntities.RegionEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SPADemo.BusinessEntities.RegionEntity> GetBy(Expression<Func<SPADemo.BusinessEntities.RegionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public BusinessEntities.RegionEntity GetSingleBy(Expression<Func<SPADemo.BusinessEntities.RegionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SPADemo.BusinessEntities.RegionEntity> GetIncluding(params Expression<Func<SPADemo.BusinessEntities.RegionEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Save(BusinessEntities.RegionEntity region)
        {
            throw new NotImplementedException();
            // SaveChanges();TODO - save changes to be done at calling method - i.e business logic
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrderEntity> GetRegionalSales()
        {
            IEnumerable<OrderEntity> regionSales = _dataContext.Query<OrderEntity>(StoreProcedureConstants.spGetRegionalSales, commandType: CommandType.StoredProcedure);

            IEnumerable<RegionEntity> regions = _dataContext.Query<RegionEntity>(StoreProcedureConstants.spGetRegionalSales, commandType: CommandType.StoredProcedure);

            List<OrderEntity> salesList = new List<OrderEntity>();

            salesList = (from o in regionSales
                         join r in regions on o.RegionID equals r.ID
                         select (new OrderEntity()
                         {
                             RegionID = o.RegionID,
                             TotalCost = o.TotalCost,
                             Region = new RegionEntity { ID = r.ID, Name = r.Name }
                         })).ToList();

            return salesList.AsEnumerable<OrderEntity>();

        }
    }
}
