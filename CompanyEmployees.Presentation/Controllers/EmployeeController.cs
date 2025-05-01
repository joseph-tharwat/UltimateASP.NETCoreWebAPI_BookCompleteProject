using Microsoft.AspNetCore.Mvc;
using Service.Contract;
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
        public IActionResult GetEmployee(Guid EmployeeId)
        {
            var employeeDto = _services.EmployeeService.GetEmployee(EmployeeId, false);
            return Ok(employeeDto);
        }

    }
}
