using JwtApi.CustomAttributes;
using JwtApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService categoryService)
        {
            service = categoryService;
        }

        [HttpPost]
        [Route("/api/category/CreateCategory")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> CreateCategory(string Name)
        {
            return await service.CreateCategory(Name);
        }

        [HttpDelete]
        [Route("/api/category/DeleteCategory")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            return await service.DeleteCategory(Id);
        }

        [HttpGet]
        [Route("/api/category/GetCategories")]
        public async Task<ActionResult> GetCategories()
        {
            return await service.GetCategories();
        }
    }
}
