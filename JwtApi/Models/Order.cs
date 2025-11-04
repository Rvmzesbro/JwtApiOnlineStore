using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime DateOrder { get; set; }
        [ForeignKey("ShippingMethod")]
        public int ShippingMethodId { get; set; }
        public virtual Status Status { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
