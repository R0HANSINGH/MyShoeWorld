using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CartDate { get; set; }
        public virtual ICollection<CartDetails>? cartDetails { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Invoice invoice { get; set; }
    }
}
