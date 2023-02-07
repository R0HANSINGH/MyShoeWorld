using System.ComponentModel.DataAnnotations;
namespace MyShoeWorld.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage="Category Name is Required Field!")]
        [MaxLength(100,ErrorMessage ="Category Name Cannot Exceed 100 Characters ")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description is Required Field!")]
        [MaxLength(500, ErrorMessage = "Category Description Cannot Exceed 500 Characters ")]
        public string? Description { get; set; }
        public virtual ICollection<Product>? products { get; set; }
    }
}