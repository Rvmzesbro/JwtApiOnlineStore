using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult> Authorization(AuthorizeUser RequestUser);
        Task<ActionResult> EditRole(int Id, int RoleId);
        Task<ActionResult> UserLog(int Id);
    }
}
