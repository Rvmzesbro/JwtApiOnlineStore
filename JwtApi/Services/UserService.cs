using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class UserService : IUserService
    {
        private readonly ContextDB db;
        public UserService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> EditRole(int Id, int RoleId)
        {
            var user = await db.Users.FirstOrDefaultAsync(p => p.Id == Id);

            if(user == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            user.RoleId = RoleId;
            db.Users.Update(user);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> UserLog(int Id)
        {
            var user = await db.Users.FirstOrDefaultAsync(p => p.Id == Id);

            if (user == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            var ListBasket = await db.Baskets.Where(p => p.UserId == Id).ToListAsync();
            var ListOrder = await db.Baskets.Where(p => p.UserId == Id).Select(p => p.Order).ToListAsync();

            if (ListBasket == null || ListBasket.Count == 0)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            if (ListOrder == null || ListOrder.Count == 0)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                basket = ListBasket,
                order = ListOrder
            });
        }
    }
}
