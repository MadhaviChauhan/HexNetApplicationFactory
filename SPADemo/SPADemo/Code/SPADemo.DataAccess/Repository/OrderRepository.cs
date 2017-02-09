using SPADemo.BusinessEntities;
using SPADemo.BusinessEntities.Filters;
using Dapper;
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
    public class OrderRepository : BaseRepository<DapperContext>, IOrderRepository
    {
        private DapperContext _dataContext;
        public OrderRepository(DapperContext dbContext)
            : base(dbContext)
        {
            _dataContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntity> GetBy(Expression<Func<OrderEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public OrderEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntity> GetIncluding(params Expression<Func<OrderEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntity> GetOrderByFilter(OrderCriteria criteria)
        {
            //Contract.Requires<ArgumentNullException>(criteria != null, "Criteria Entity cannot be null.");

            var parm = new DynamicParameters();
            parm.AddDynamicParams(criteria);

            IEnumerable<OrderEntity> orders = _dataContext.Query<OrderEntity>(StoreProcedureConstants.spGetOrderByFilter, parm, commandType: CommandType.StoredProcedure);

            IEnumerable<CustomerEntity> customers = _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetOrderByFilter, parm, commandType: CommandType.StoredProcedure);

            List<OrderEntity> orderList = new List<OrderEntity>();

            orderList = (from o in orders
                         join c in customers on o.Id equals c.Id
                         select (new OrderEntity()
                         {
                             Id = o.Id,
                             CustomerId = o.CustomerId,
                             Customer = new CustomerEntity() { Name = c.Name, Address = c.Address },
                             OrderDate = o.OrderDate,
                             Carrier = o.Carrier,
                             SalesPerson = o.SalesPerson,
                             Boxes = o.Boxes,
                             TotalCost = o.TotalCost,
                             OrderStatus = o.OrderStatus
                         })).ToList();



            return orderList.AsEnumerable<OrderEntity>();
        }

        public IEnumerable<OrderEntity> GetOrderBySort(OrderCriteria criteria, string sortObject)
        {

            var parm = new DynamicParameters();

            parm.AddDynamicParams(new
            {
                criteria.OrderNo,
                criteria.Customer,
                criteria.OrderDateFrom,
                criteria.OrderDateTo,
                criteria.SalesPerson,
                criteria.Carrier,
                criteria.Status,
                sortObject
            });

            IEnumerable<OrderEntity> orders = _dataContext.Query<OrderEntity>(StoreProcedureConstants.spGetOrderBySort, parm, commandType: CommandType.StoredProcedure);

            IEnumerable<CustomerEntity> customers = _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetOrderBySort, parm, commandType: CommandType.StoredProcedure);

            List<OrderEntity> orderList = new List<OrderEntity>();
            orderList = (from o in orders
                         join c in customers on o.Id equals c.Id
                         select (new OrderEntity()
                         {
                             Id = o.Id,
                             CustomerId = o.CustomerId,
                             Customer = new CustomerEntity() { Name = c.Name, Address = c.Address },
                             OrderDate = o.OrderDate,
                             Carrier = o.Carrier,
                             SalesPerson = o.SalesPerson,
                             Boxes = o.Boxes,
                             TotalCost = o.TotalCost,
                             OrderStatus = o.OrderStatus
                         })).ToList();

            return orderList.AsEnumerable<OrderEntity>();
        }

        public IEnumerable<OrderEntity> GetOrderDetailByOrderNo(int orderNo)
        {
            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                orderNo
            });

            IEnumerable<OrderEntity> orders = _dataContext.Query<OrderEntity>(StoreProcedureConstants.spGetOrderDetailByOrderNo, param, commandType: CommandType.StoredProcedure);
            IEnumerable<CustomerEntity> customers = _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetOrderDetailByOrderNo, param, commandType: CommandType.StoredProcedure);

            List<OrderEntity> orderList = new List<OrderEntity>();
            orderList = (from o in orders
                         join c in customers on o.Id equals c.Id
                         select (new OrderEntity()
                         {
                             Id = o.Id,
                             CustomerId = o.CustomerId,
                             Customer = new CustomerEntity() { Name = c.Name, Address = c.Address },
                             OrderDate = o.OrderDate,
                             OrderStatus = o.OrderStatus
                         })).ToList();

            return orderList.AsEnumerable<OrderEntity>();
        }

        public IEnumerable<OrderEntityDetail> GetOrderProductByOrderNo(int orderNo)
        {
            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                orderNo
            });

            IEnumerable<OrderEntityDetail> details = _dataContext.Query<OrderEntityDetail>(StoreProcedureConstants.spGetOrderProductByOrderNo, param, commandType: CommandType.StoredProcedure);
            IEnumerable<ProductEntity> products = _dataContext.Query<ProductEntity>(StoreProcedureConstants.spGetOrderProductByOrderNo, param, commandType: CommandType.StoredProcedure);

            List<OrderEntityDetail> detailList = new List<OrderEntityDetail>();

            detailList = (from o in details
                          join p in products on o.Id equals p.Id
                          select (new OrderEntityDetail()
                          {
                              Product = new ProductEntity()
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  IsInStock = p.IsInStock
                              },
                              Quantity = o.Quantity,
                              UnitPrice = o.UnitPrice,
                              Discount = o.Discount,
                              TotalPrice = ((o.Quantity * o.UnitPrice) - o.Discount)
                          })).ToList();




            return detailList.AsEnumerable<OrderEntityDetail>();
        }

        public OrderEntity GetSingleBy(Expression<Func<OrderEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }


}
