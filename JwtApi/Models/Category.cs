using System.ComponentModel.DataAnnotations;

namespace JwtApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
