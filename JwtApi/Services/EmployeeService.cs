using JwtApi.Interfaces;
using JwtApi.Models;
using JwtApi.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Numerics;

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

        public async Task<ActionResult> GetAllEmployee()
        {
            var ListEmployee = await db.Users.Where(p => p.Id == 2).ToListAsync();

            if(ListEmployee == null || ListEmployee.Count == 0)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                list = ListEmployee
            });
        }

        public async Task<ActionResult> UpdateEmployee(int Id, CreateEmployee UpdateEmployee)
        {
            var update_employee = await db.Users.FirstOrDefaultAsync(p => p.Id == Id && p.RoleId == 2);

            if (update_employee == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            update_employee.Email = UpdateEmployee.Email;
            update_employee.Password = UpdateEmployee.Password;
            update_employee.FullName = UpdateEmployee.FullName;
            update_employee.Phone = UpdateEmployee.Phone;
            update_employee.UpdatedAt = DateTime.UtcNow;
            update_employee.AdressDelivery = null;
            update_employee.RoleId = 2;

            db.Users.Update(update_employee);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            var DeleteEmployee = await db.Users.FirstOrDefaultAsync(p => p.Id == Id && p.RoleId == 2);

            if(DeleteEmployee == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            db.Users.Remove(DeleteEmployee);
            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }
    }
}
