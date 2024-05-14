using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.Model
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public virtual Order ?Order { get; set; }
        public virtual Product ?Product { get; set; }
    }
}
