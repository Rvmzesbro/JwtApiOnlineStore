using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JwtApi.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ContextDB db;
        private readonly IHttpContextAccessor context;
        public ProfileService(ContextDB contextDB, IHttpContextAccessor httpContextAccessor)
        {
            db = contextDB; 
            context = httpContextAccessor;
        }

        public async Task<ActionResult> EditProfile(ProfileModel current_user)
        {
            int IdCurrentUser = (int)context.HttpContext.Items["CurrentUserId"];
            var user = await db.Users.FirstOrDefaultAsync(p => p.Id == IdCurrentUser);

            if (user == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            bool IsEmail = await db.Users.AllAsync(p => p.Email == current_user.Email && p.Id != IdCurrentUser);
            if (IsEmail)
            {
                return new OkObjectResult(new
                {
                    status = false,
                    message = "Этот Email уже используется"
                });
            }

            user.FullName = current_user.FullName;
            user.Email = current_user.Email;
            user.Password = current_user.Password;
            user.Phone = current_user.Phone;

            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

    }
}
