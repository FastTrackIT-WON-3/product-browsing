using System.ComponentModel.DataAnnotations;

namespace ProductBrowsing.Mvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public CategoryViewModel Category { get; set; } = new CategoryViewModel();
    }
}
