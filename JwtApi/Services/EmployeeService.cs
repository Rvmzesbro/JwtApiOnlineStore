using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ContextDB db;
        public EmployeeService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> CreateEmployee(CreateEmployee NewEmployee)
        {
            var new_employee = new User()
            {
                Email = NewEmployee.Email,
                Password = NewEmployee.Password,
                FullName = NewEmployee.FullName,
                Phone = NewEmployee.Phone,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                AdressDelivery = null,
                RoleId = 2
            };

            await db.Users.AddAsync(new_employee);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }
    }
}
