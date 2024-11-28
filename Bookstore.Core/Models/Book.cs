using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Models
{
    public class Book : Entity
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
