using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Name is required field")]
        [MaxLength(100, ErrorMessage = "Customer Name cannot exceed 100 character")]
        public string? ContactName { get; set; }
        [Required(ErrorMessage = "Address is required field")]
        [MaxLength(500, ErrorMessage = "Address cannot exceed 100 character")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is required field")]
        [MaxLength(100, ErrorMessage = "City cannot exceed 100 character")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Phone Number is required field")]
        [MaxLength(15, ErrorMessage = "Phone number cannot exceed 100 character")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Email id is required field")]
        [EmailAddress(ErrorMessage = "Email must be in correct format for eg. john@gmail.com")]
        [MaxLength(100, ErrorMessage = "Email Id cannot exceed 100 character")]
        public string? Email { get; set; }
        public virtual ICollection<Cart>? carts { get; set; }

    }
}