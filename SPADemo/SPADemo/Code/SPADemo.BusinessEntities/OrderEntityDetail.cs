namespace SPADemo.BusinessEntities
{
    public partial class OrderEntityDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }

        public double TotalPrice { get; set; }

        public virtual OrderEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
