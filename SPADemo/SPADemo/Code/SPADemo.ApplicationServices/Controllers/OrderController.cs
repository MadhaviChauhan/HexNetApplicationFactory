using SPADemo.BusinessEntities;
using SPADemo.BusinessEntities.Filters;
using SPADemo.BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SPADemo.ApplicationServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("api/Order/GetOrders/{status?}/{orderNo?}/{customer?}/{orderDateFrom?}/{orderDateTo?}/{salesPerson?}/{carrier?}")]
        public IEnumerable<OrderEntity> GetOrderByFilter(string status, System.Nullable<int> orderNo = null, string customer = "", System.Nullable<DateTime> orderDateFrom = null, System.Nullable<DateTime> orderDateTo = null, string salesPerson = "", string carrier = "")
        {
            OrderCriteria criteria = new OrderCriteria()
            {
                OrderNo = orderNo,
                Customer = customer,
                OrderDateFrom = orderDateFrom,
                OrderDateTo = orderDateTo,
                SalesPerson = salesPerson,
                Carrier = carrier,
                Status = status
            };
            var orders = _orderService.GetOrderByFilter(criteria);
            return (orders) as IEnumerable<OrderEntity>;
        }

        [HttpGet]
        [Route("api/Order/GetOrdersBySort/{status?}/{orderNo?}/{customer?}/{orderDateFrom?}/{orderDateTo?}/{salesPerson?}/{carrier?}/{sortObject?}")]
        public IEnumerable<OrderEntity> GetOrderBySort(string status, System.Nullable<int> orderNo = null, string customer = "", System.Nullable<DateTime> orderDateFrom = null, System.Nullable<DateTime> orderDateTo = null, string salesPerson = "", string carrier = "", string sortObject = "")
        {
            OrderCriteria criteria = new OrderCriteria()
            {
                OrderNo = orderNo,
                Customer = customer,
                OrderDateFrom = orderDateFrom,
                OrderDateTo = orderDateTo,
                SalesPerson = salesPerson,
                Carrier = carrier,
                Status = status
            };
            var orders = _orderService.GetOrderBySort(criteria, sortObject);
            return (orders) as IEnumerable<OrderEntity>;
        }

        [HttpGet]
        [Route("api/Order/OrderDetails/{orderNo}")]
        public IEnumerable<OrderEntity> GetOrderDetailByOrderNo(int orderNo)
        {
            var orders = _orderService.GetOrderDetailByOrderNo(orderNo);

            return (orders) as IEnumerable<OrderEntity>;
        }

        [HttpGet]
        [Route("api/Order/ProductDetails/{orderNo}")]
        public IEnumerable<OrderEntityDetail> GetOrderProductByOrderNo(int orderNo)
        {
            var orders = _orderService.GetOrderProductByOrderNo(orderNo);
            return (orders) as IEnumerable<OrderEntityDetail>;
        }
    }
}
