using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is Required Field!")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = "Product Unit Price is Required Field!")]
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "Product Name is Required Field!")]
        public string? Description { get; set;}
        [Required(ErrorMessage = "Manufacturig Date is Required Field!")]
        public DateTime ManufacturingDate{ get; set; }
        [Required(ErrorMessage = "Made In is Required Field!")]
        public string? MadeIn { get; set; }
        [Required(ErrorMessage = "Shoe Type is Required Field!")]
        public string? ShoeType { get; set; }
        [Required(ErrorMessage = "Gender is Required Field!")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Warranty Period  is Required Field!")]
        public string? WarrantyPeriod { get; set; }
        [Required(ErrorMessage = "Return Policy  is Required Field!")]
        [MaxLength(100, ErrorMessage = "Return Policy cannot exceed 100 character")]
        public string? ReturnPolicy { get; set; }
        [Required(ErrorMessage = "Quantity is Required Field!")]
        public int Quantity { get; set; }

        [Range(0,70, ErrorMessage = "Discount must be between 0 to 70 Percent!")]
        public int Discount { get; set; }
        [MaxLength(100, ErrorMessage = "Picture cannot exceed 100 characte!")]
        public string? Picture { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? category { get; set; }
    }
}
