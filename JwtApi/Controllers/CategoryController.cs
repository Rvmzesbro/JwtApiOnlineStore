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
        public async Task<ActionResult> CreateCategory(string Name)
        {
            return await service.CreateCategory(Name);
        }

        [HttpDelete]
        [Route("/api/category/DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            return await service.DeleteCategory(Id);
        }
    }
}
