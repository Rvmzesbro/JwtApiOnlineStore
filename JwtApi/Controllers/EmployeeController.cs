using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeService _EmployeeServices;
        public EmployeeController(IEmployeeService employeeService)
        {
            _EmployeeServices = employeeService;
        }

        [HttpPost]
        [Route("/api/employee/CreateEmployee")]
        public async Task<ActionResult> CreateEmployee(CreateEmployee NewEmployee)
        {
            return await _EmployeeServices.CreateEmployee(NewEmployee);
        }
    }
}
