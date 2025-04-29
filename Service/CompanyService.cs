using Contracts.IRepositoy;
using Contracts.Logger;
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
            try
            {
                return _repository.Company.GetCompanies().Select(c => new CompanyDto(
                c.Id, c.Name,
                c.Address + ", " + c.Country
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInfo("Error getting the companies"+ ex.Message);
                throw;
            }
        }
    }
}
