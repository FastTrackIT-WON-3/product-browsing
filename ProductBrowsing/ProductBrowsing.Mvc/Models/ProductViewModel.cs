using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductBrowsing.Mvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name="Product Name")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Selected Category")]
        [Required]
        public int SelectedCategoryId { get; set; }

        public List<SelectListItem> AllAvailableCategories { get; set; } = new List<SelectListItem>();
    }
}
