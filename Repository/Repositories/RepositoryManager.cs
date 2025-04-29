using Contracts.IRepositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _dbContext;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private Lazy<ICompanyRepository> _companyRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _dbContext = context;
            _employeeRepository = new Lazy<IEmployeeRepository>(new EmployeeRepository(context));
            _companyRepository = new Lazy<ICompanyRepository>(new CompanyRepository(context));
        }
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public ICompanyRepository Company => _companyRepository.Value;

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
