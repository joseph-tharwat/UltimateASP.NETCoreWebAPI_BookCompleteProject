using AutoMapper;
using Contracts.IRepositoy;
using Contracts.Logger;
using Entities.Exceptions;
using Entities.Models;
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
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerService loggerService, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerService;    
            _mapper = mapper;
        }

        public List<CompanyDto> GetCompanies()
        {
            _logger.LogDebuge("Get Companies");

            var companiesEntity = _repository.Company.GetCompanies();

            if(companiesEntity.Count == 0)
            {
                throw new CompanyNotFoundException();
            }
            var companiesDto = _mapper.Map<List<CompanyDto>>(companiesEntity);
            return companiesDto;
        }

        public List<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if(ids.Count() == 0)
            {
                throw new Exception("Bad request: ids is empty");
            }

            var companiesEntity = _repository.Company.GetByIds(ids);
            if(companiesEntity.Count == 0)
            {
                throw new CompanyNotFoundException();
            }

            _logger.LogInfo("GetByIds...");

            var companiesDto = _mapper.Map<List<CompanyDto>>(companiesEntity);

            return companiesDto;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto companyForCreationDto)
        {
            if(companyForCreationDto == null)
            {
                throw new Exception("null company");
            }

            Company companyEntity = _mapper.Map<Company>(companyForCreationDto);
        
            _repository.Company.CreateCompany(companyEntity);
            _repository.save();

            CompanyDto companyToReturn  = _mapper.Map<CompanyDto>(companyEntity);
            return companyToReturn;
        }

        public CompanyDto GetCompanyById(Guid id, bool trackChanges)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id");
            }

            Company company = _repository.Company.GetCompanyById(id, trackChanges);
            if(company==null)
            {
                throw new CompanyNotFoundException();
            }

            CompanyDto companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }
}
