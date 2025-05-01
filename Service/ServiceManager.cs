using AutoMapper;
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
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<ICompanyService>  _companyService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService loggerService, IMapper mapper)
        {
            _employeeService = new Lazy<IEmployeeService>(()=> new EmployeeService(repositoryManager,loggerService, mapper));
            _companyService = new Lazy<ICompanyService>(()=> new CompanyService(repositoryManager,loggerService, mapper));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;

        public ICompanyService CompanyService => _companyService.Value;
    }
}
