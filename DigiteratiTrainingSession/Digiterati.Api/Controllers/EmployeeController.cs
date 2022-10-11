using Core.ViewModel;
using Digiterati.Core.Abstractions;
using Digiterati.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Digiterati.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService  employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet,Route("GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public IActionResult GetEmployee()
        {
            var result = _employeeService.GetEmployee();
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpGet, Route("GetAllEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> GetAllEmployee(int employeeId)
        {
            var result = await _employeeService.GetAllEmployee(employeeId);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }
    }
}
