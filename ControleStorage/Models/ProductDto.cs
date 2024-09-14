using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ControleStorage.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brand { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Category { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; } = "";
        public IFormFile? ImageFile { get; set; }
    }
}
