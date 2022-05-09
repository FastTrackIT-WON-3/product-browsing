using System.ComponentModel.DataAnnotations;

namespace ProductBrowsing.Mvc.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
