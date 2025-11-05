using JwtApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class UserController
    {
        private readonly IUserService service;
        public UserController(IUserService userService)
        {
            service = userService;
        }

        [HttpPut]
        [Route("/api/user/EditRole")]
        public async Task<ActionResult> EditRole(int Id, int RoleId)
        {
            return await service.EditRole(Id, RoleId);
        }

        [HttpGet]
        [Route("/api/user/UserLog")]
        public async Task<ActionResult> UserLog(int Id)
        {
            return await service.UserLog(Id);
        }
    }
}
