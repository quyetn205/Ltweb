using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tvcday08cf.Models
{
    [Table(name: "Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
