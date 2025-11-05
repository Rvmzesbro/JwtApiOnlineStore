using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IClientService
    {
        Task<ActionResult> GetClientById(int Id);
        Task<ActionResult> UpdateClient(int Id, CreateClient UpdateClient);
        Task<ActionResult> DeleteClient(int Id);
    }
}
