using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Model
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
