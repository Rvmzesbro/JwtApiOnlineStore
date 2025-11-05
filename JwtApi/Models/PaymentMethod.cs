using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtApi.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int CodeCVC { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
