using System.Collections.Generic;

namespace SPADemo.BusinessEntities
{
    public partial class CustomerEntity
    {
        public CustomerEntity()
        {
            this.Orders = new HashSet<OrderEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }

    }
}
