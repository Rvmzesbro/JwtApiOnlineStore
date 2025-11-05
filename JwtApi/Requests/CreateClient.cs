using System.ComponentModel.DataAnnotations;

namespace JwtApi.Requests
{
    public class CreateClient
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string AdressDelivery { get; set; }
        [Required]
        //[Range(1000000000000000, 9999999999999999, ErrorMessage = "Введите ровно 16 цифр")]
        public int CardNumber { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Введен неверный формат")]
        public string ExpiryDate { get; set; }
        [Required]
        //[Range(100, 3, ErrorMessage = "Введен неверный формат")]
        public int CodeCVC { get; set; }
    }
}
