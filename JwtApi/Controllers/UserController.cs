using JwtApi.CustomAttributes;
using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("/api/user/Authorization")]
        public async Task<ActionResult> Authorization(AuthorizeUser RequestUser)
        {
            return await service.Authorization(RequestUser);
        }

        [HttpPut]
        [Route("/api/user/EditRole")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> EditRole(int Id, int RoleId)
        {
            return await service.EditRole(Id, RoleId);
        }

        [HttpGet]
        [Route("/api/user/UserLog")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> UserLog(int Id)
        {
            return await service.UserLog(Id);
        }
    }
}
