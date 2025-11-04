using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IEmployeeService
    {
        Task<ActionResult> CreateEmployee(CreateEmployee NewEmployee);
    }
}
