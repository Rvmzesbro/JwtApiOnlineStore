using JwtApi.CustomAttributes;
using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class ProfileController
    {
        private readonly IProfileService service;
        public ProfileController(IProfileService profileService)
        {
            service = profileService;
        }

        [HttpPut]
        [Route("/api/profile/EditProfile")]
        [RoleAuthorize([1, 2])]
        public async Task<ActionResult> EditProfile(ProfileModel current_user)
        {
            return await service.EditProfile(current_user);
        }

    }
}
