using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiController]
    [Route("{CompanyId}")]
    public class EmployeeController:ControllerBase
    {
        private readonly IServiceManager _services;
        public EmployeeController(IServiceManager serviceManager) 
        { 
            _services = serviceManager;
        }

        [HttpGet]
        public IActionResult GetEmployee(Guid EmployeeId, [FromQuery] EmployeeParameters employeeParameters)
        {
            var employeeDto = _services.EmployeeService.GetEmployee(EmployeeId, false);
            return Ok(employeeDto);
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees(Guid CompanyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            var employeeDto = _services.EmployeeService.GetEmployees(CompanyId, false, employeeParameters);
            return Ok(employeeDto);
        }

    }
}
