using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IEmployeeService
    {
        Task<ActionResult> CreateEmployee(CreateEmployee NewEmployee);
        Task<ActionResult> GetAllEmployee();
        Task<ActionResult> UpdateEmployee(int Id, CreateEmployee UpdateEmployee);
        Task<ActionResult> DeleteEmployee(int Id);
    }
}
