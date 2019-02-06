using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tees.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Category name can't be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters." )]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Cateogory names must begin with a capital letter and only consist of only letters and spaces." )]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}