using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    }
}
