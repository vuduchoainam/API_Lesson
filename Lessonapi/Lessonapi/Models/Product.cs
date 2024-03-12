namespace Lessonapi.Models
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public class Product : ProductVM 
    {
        public Guid Id { get; set; }
    }
}
