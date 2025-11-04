using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtApi.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public decimal CountProduct { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
