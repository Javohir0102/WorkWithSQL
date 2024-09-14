using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ControleStorage.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Description { get; set; } = "";
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedDate { get; set; }
    }
}
