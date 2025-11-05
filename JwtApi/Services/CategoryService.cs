using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ContextDB db;
        public CategoryService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> CreateCategory(string Name)
        {
            var NewCategory = new Category()
            {
                Name = Name
            };

            await db.Categories.AddAsync(NewCategory);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                statsus = true
            });
        }

        public async Task<ActionResult> DeleteCategory(int Id)
        {
            var category = await db.Categories.FirstOrDefaultAsync(p => p.Id == Id);

            if(category == null)
            {
                return new OkObjectResult(new
                {
                    statsus = false
                });
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                statsus = true
            });
        }
    }
}
