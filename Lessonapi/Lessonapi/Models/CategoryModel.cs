using System.ComponentModel.DataAnnotations;

namespace Lessonapi.Models
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
