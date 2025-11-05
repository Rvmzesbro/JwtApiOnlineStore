using System.ComponentModel.DataAnnotations.Schema;

namespace JwtApi.Requests
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public string Category { get; set; }
    }
}
