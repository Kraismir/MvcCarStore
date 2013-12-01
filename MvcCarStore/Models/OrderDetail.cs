using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcCarStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public int CarID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }
    }
}
