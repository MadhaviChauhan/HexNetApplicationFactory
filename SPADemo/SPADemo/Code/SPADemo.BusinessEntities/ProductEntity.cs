using System.Collections.Generic;

namespace SPADemo.BusinessEntities
{
    public partial class ProductEntity
    {
        public ProductEntity()
        {
            this.OrderDetails = new HashSet<OrderEntityDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInStock { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<OrderEntityDetail> OrderDetails { get; set; }
    }
}
