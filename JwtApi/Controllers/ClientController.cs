using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class ClientController
    {
        private readonly IClientService service;
        public ClientController(IClientService clientService)
        {
            service = clientService;
        }

        [HttpGet]
        [Route("/api/client/GetClientById")]
        public async Task<ActionResult> GetClientById(int Id)
        {
            return await service.GetClientById(Id);
        }

        [HttpPut]
        [Route("/api/client/UpdateClient")]
        public async Task<ActionResult> UpdateClient(int Id, CreateClient UpdateClient)
        {
            return await service.UpdateClient(Id, UpdateClient);
        }

        [HttpDelete]
        [Route("/api/client/DeleteClient")]
        public async Task<ActionResult> DeleteClient(int Id)
        {
            return await service.DeleteClient(Id);
        }
    }
}
