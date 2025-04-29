using Contracts.IRepositoy;
using Contracts.Logger;
using Entities.Exceptions;
using Service.Contract;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CompanyService:ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerService loggerService)
        {
            _repository = repositoryManager;
            _logger = loggerService;    
        }

        public List<CompanyDto> GetCompanies()
        {
            _logger.LogDebuge("Get Companies");

            var companies =  _repository.Company.GetCompanies().Select(c => new CompanyDto(
                c.Name,
                c.Address + ", " + c.Country
                )).ToList();

            if(companies.Count == 0)
            {
                _logger.LogInfo("Get Companies: Company not found");
                throw new CompanyNotFoundException();
            }

            return companies;
        }
    }
}
