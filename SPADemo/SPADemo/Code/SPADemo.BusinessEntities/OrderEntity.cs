using System.Collections.Generic;

namespace SPADemo.BusinessEntities
{
    public partial class OrderEntity
    {
        public OrderEntity()
        {
            this.OrderDetails = new HashSet<OrderEntityDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int RegionID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string Carrier { get; set; }
        public string SalesPerson { get; set; }
        public int Boxes { get; set; }
        public float TotalCost { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        public virtual ICollection<OrderEntityDetail> OrderDetails { get; set; }

        public virtual RegionEntity Region { get; set; }
    }
}
