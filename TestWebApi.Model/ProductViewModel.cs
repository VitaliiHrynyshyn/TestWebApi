using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
    }
}
