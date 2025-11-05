using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IProductService
    {
        Task<ActionResult> CreateProduct(CreateProduct NewProduct);
        Task<ActionResult> UpdateProduct(int Id, CreateProduct UpdateProduct);
        Task<ActionResult> DeleteProduct(int Id);
        Task<ActionResult> GetProductById(int Id);
    }
}
