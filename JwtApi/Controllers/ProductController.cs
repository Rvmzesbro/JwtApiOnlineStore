using JwtApi.CustomAttributes;
using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class ProductController
    {
        private readonly IProductService service;
        public ProductController(IProductService productService)
        {
            service = productService;
        }

        [HttpPost]
        [Route("/api/product/CreateProduct")]
        [RoleAuthorize([1, 2])]
        public async Task<ActionResult> CreateProduct(CreateProduct NewProduct)
        {
            return await service.CreateProduct(NewProduct);
        }

        [HttpPut]
        [Route("/api/product/UpdateProduct")]
        [RoleAuthorize([1, 2])]
        public async Task<ActionResult> UpdateProduct(int Id, CreateProduct NewProduct)
        {
            return await service.UpdateProduct(Id, NewProduct);
        }

        [HttpDelete]
        [Route("/api/product/DeleteProduct")]
        [RoleAuthorize([1, 2])]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            return await service.DeleteProduct(Id);
        }

        [HttpGet]
        [Route("/api/product/GetProductById")]
        [RoleAuthorize([1, 2])]
        public async Task<ActionResult> GetProductById(int Id)
        {
            return await service.GetProductById(Id);
        }
    }
}
