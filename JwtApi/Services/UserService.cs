using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using JwtApi.UniversalMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class UserService : IUserService
    {
        private readonly ContextDB db;
        private readonly JwtGenerator generator;
        public UserService(ContextDB contextDB, JwtGenerator jwtGenerator)
        {
            db = contextDB;
            generator = jwtGenerator;
        }

        public async Task<ActionResult> Authorization(AuthorizeUser RequestUser)
        {
            var user = await db.Users.FirstOrDefaultAsync(p => p.Email.ToLower() == RequestUser.Email.ToLower() && p.Password.ToLower() == RequestUser.Password.ToLower());

            if(user == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            string token = generator.GenerateToken(user.Id, user.RoleId);
            var session = new Session()
            {
                Token = token,
                UserId = user.Id
            };

            await db.Sessions.AddAsync(session);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                token = token
            });
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
