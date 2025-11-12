using JwtApi.CustomAttributes;
using JwtApi.Interfaces;
using JwtApi.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService employeeService)
        {
            service = employeeService;
        }

        [HttpPost]
        [Route("/api/employee/CreateEmployee")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> CreateEmployee([FromBody]CreateEmployee NewEmployee)
        {
            return await service.CreateEmployee(NewEmployee);
        }

        [HttpGet]
        [Route("/api/employee/GetAllEmployee")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> GetAllEmployee()
        {
            return await service.GetAllEmployee();
        }

        [HttpPut]
        [Route("/api/employee/UpdateEmployee")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> UpdateEmployee(int Id, CreateEmployee UpdateEmployee)
        {
            return await service.UpdateEmployee(Id, UpdateEmployee);
        }

        [HttpDelete]
        [Route("/api/employee/DeleteEmployee")]
        [RoleAuthorize([1])]
        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            return await service.DeleteEmployee(Id);
        }
    }
}
