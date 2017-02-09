using SPADemo.BusinessEntities;
using SPADemo.BusinessEntities.Filters;
using SPADemo.DataAccessInterface.Repository;
using System.Collections.Generic;

namespace SPADemo.DataAccessInterface
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        IEnumerable<SPADemo.BusinessEntities.OrderEntity> GetOrderByFilter(OrderCriteria criteria);

        IEnumerable<OrderEntity> GetOrderDetailByOrderNo(int orderNo);
        IEnumerable<OrderEntityDetail> GetOrderProductByOrderNo(int orderNo);

        IEnumerable<SPADemo.BusinessEntities.OrderEntity> GetOrderBySort(OrderCriteria criteria, string sortObject);
    }
}
