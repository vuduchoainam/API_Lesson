using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lessonapi.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }


        [Range(0, Double.MaxValue)]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }



        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
