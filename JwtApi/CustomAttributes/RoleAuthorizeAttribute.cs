using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Primitives;

namespace JwtApi.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int[] _roleId;
        public RoleAuthorizeAttribute(int[] roleId)
        {
            _roleId = roleId;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var db = context.HttpContext.RequestServices.GetRequiredService<ContextDB>();
            string? token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new { error = "Сессия не передана" }) { StatusCode = 401 };
                return;
            }

            var session = await db.Sessions.Include(p => p.User).FirstOrDefaultAsync(p => p.Token == token);

            if (session == null)
            {
                context.Result = new JsonResult(new { error = "Сессия не найдена" }) { StatusCode = 401 };
                return;
            }

            context.HttpContext.Items["CurrentUserId"] = session.UserId;

            if (!_roleId.Contains(session.UserId))
            {
                context.Result = new JsonResult(new { error = "Недостаточно прав" }) { StatusCode = 403 };
                return;
            }

            await next();
        }
    }
}
