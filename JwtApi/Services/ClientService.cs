using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class ClientService : IClientService
    {
        private readonly ContextDB db;
        public ClientService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> GetClientById(int Id)
        {
            var client = await db.Users.FirstOrDefaultAsync(p => p.Id == Id);
            if(client == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                client = client
            });
        }

        public async Task<ActionResult> UpdateClient(int Id, CreateClient UpdateClient)
        {
            var update_client = await db.Users.FirstOrDefaultAsync(p => p.Id == Id && p.RoleId == 3);
            var update_paymethod = await db.PaymentMethods.FirstOrDefaultAsync(p => p.UserId == update_client.Id);

            if (update_client == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            if (update_paymethod == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            update_client.FullName = UpdateClient.FullName;
            update_client.Email = UpdateClient.Email;
            update_client.Password = UpdateClient.Password;
            update_client.Phone = UpdateClient.Phone;
            update_client.AdressDelivery = UpdateClient.AdressDelivery;
            update_client.UpdatedAt = DateTime.UtcNow;
            db.Users.Update(update_client);

            update_paymethod.CardNumber = UpdateClient.CardNumber;
            update_paymethod.ExpiryDate = UpdateClient.ExpiryDate;
            update_paymethod.CodeCVC = UpdateClient.CodeCVC;
            db.PaymentMethods.Update(update_paymethod);

            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> DeleteClient(int Id)
        {
            var DeleteClient = await db.Users.FirstOrDefaultAsync(p => p.Id == Id && p.RoleId == 3);

            if(DeleteClient == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            db.Users.Remove(DeleteClient);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }
    }
}
