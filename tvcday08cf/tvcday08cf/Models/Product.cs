using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tvcday08cf.Models
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
