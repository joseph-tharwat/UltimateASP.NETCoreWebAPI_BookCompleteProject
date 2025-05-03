using CompanyEmployees.Presentation.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CompaniesController(IServiceManager serviceManager)
        {
            _services = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
                var companies = _services.CompanyService.GetCompanies();
                return Ok(companies);
        }

        [HttpGet("{id}",Name ="GetCompanyById")]
        public IActionResult GetCompanyById(Guid id)
        {
            var company = _services.CompanyService.GetCompanyById(id,false);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyForCreationDto company)
        {
            var companyDto = _services.CompanyService.CreateCompany(company);
            return CreatedAtRoute("GetCompanyById", new { id=companyDto.Id}, companyDto);
        }


        [HttpGet("Collection/({ids})",Name ="GetCollectionCompanies")]
        public IActionResult GetCollectionCompanies([ModelBinder(BinderType = typeof(ArrayModelBinding))]IEnumerable<Guid> ids)
        {
            var companies = _services.CompanyService.GetByIds(ids, false);
            return Ok(companies);
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteCompany(Guid id)
        {
            _services.CompanyService.DeleteCompany(id);
            return NoContent();
        }

    }
}
