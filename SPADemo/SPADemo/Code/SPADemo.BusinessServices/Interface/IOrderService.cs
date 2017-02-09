using SPADemo.BusinessEntities;
using SPADemo.BusinessEntities.Filters;
using System.Collections.Generic;

namespace SPADemo.BusinessServices.Interface
{
    public interface IOrderService
    {
        IEnumerable<OrderEntity> GetOrderByFilter(OrderCriteria criteria);

        IEnumerable<OrderEntity> GetOrderBySort(OrderCriteria criteria, string sortObject);

        IEnumerable<OrderEntity> GetOrderDetailByOrderNo(int orderNo);

        IEnumerable<OrderEntityDetail> GetOrderProductByOrderNo(int orderNo);
    }
}
