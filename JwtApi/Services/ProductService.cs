using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ContextDB db;
        public ProductService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> CreateProduct(CreateProduct NewProduct)
        {
            var category = await db.Categories.FirstOrDefaultAsync(p => p.Name.ToLower() == NewProduct.Category.ToLower());

            if(category == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            var product = new Product()
            {
                Name = NewProduct.Name,
                Description = NewProduct.Description,
                Price = NewProduct.Price,
                Count = NewProduct.Count,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                CategoryId = category.Id,
                Image = null
            };

            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> UpdateProduct(int Id, CreateProduct UpdateProduct)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if(product == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            var category = await db.Categories.FirstOrDefaultAsync(p => p.Name.ToLower() == UpdateProduct.Category.ToLower());

            if (category == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            product.Name = UpdateProduct.Name;
            product.Description = UpdateProduct.Description;
            product.Price = UpdateProduct.Price;
            product.Count = UpdateProduct.Count;
            product.CategoryId = category.Id;

            db.Products.Update(product);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> DeleteProduct(int Id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> GetProductById(int Id)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                product = product
            });
        }
    }
}
