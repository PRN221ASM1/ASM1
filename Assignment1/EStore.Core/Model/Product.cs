using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public float Weight { get;set; }
        public float UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public virtual Category? Category { get; set; } = new Category();
        public virtual IEnumerable<OrderDetail> ?OrderDetails { get; set; } = new List<OrderDetail>();
        
    }
}
