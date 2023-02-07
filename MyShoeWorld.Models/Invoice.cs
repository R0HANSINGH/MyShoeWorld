using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CartId { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
