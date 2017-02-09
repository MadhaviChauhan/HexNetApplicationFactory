using SPADemo.BusinessEntities;
using SPADemo.BusinessEntities.Filters;
using SPADemo.BusinessServices.Interface;
using SPADemo.DataAccessInterface.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace SPADemo.BusinessServices
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderEntity> GetOrderByFilter(OrderCriteria criteria)
        {
            return _unitOfWork.OrderRepository.GetOrderByFilter(criteria);
        }

        public IEnumerable<OrderEntity> GetOrderBySort(OrderCriteria criteria, string sortObject)
        {
            var results = _unitOfWork.OrderRepository.GetOrderBySort(criteria, sortObject);

            return results;

        }

        public IEnumerable<OrderEntity> GetOrderDetailByOrderNo(int orderNo)
        {

            var orderList = _unitOfWork.OrderRepository.GetOrderDetailByOrderNo(orderNo);

            var detailList = _unitOfWork.OrderRepository.GetOrderProductByOrderNo(orderNo);

            orderList.First().OrderDetails = detailList.ToList();

            return orderList;

        }
        public IEnumerable<OrderEntityDetail> GetOrderProductByOrderNo(int orderNo)
        {

            return _unitOfWork.OrderRepository.GetOrderProductByOrderNo(orderNo);
        }
    }
}
