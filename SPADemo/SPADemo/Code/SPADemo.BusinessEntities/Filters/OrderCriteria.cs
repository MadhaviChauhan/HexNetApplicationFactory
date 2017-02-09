using System;

namespace SPADemo.BusinessEntities.Filters
{
    public class OrderCriteria : IFilterCriteria
    {
        public int? OrderNo { get; set; }
        public string Customer { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public string SalesPerson { get; set; }
        public string Carrier { get; set; }
        public string Status { get; set; }

    }
}
