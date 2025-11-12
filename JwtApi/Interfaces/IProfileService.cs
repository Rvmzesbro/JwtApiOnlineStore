using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IProfileService
    {
        Task<ActionResult> EditProfile(ProfileModel current_user);
    }
}
