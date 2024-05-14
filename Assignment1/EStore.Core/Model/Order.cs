using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequireDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Freight { get; set; }
        public virtual Member? Member { get; set; } = new Member();
        public virtual IEnumerable<OrderDetail> ?OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
