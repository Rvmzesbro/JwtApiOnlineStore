using System.ComponentModel.DataAnnotations;

namespace JwtApi.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
