using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositoy
{
    public interface ICompanyRepository
    {
        public List<Company> GetCompanies();
        public Company GetCompanyById(Guid id, bool trackChanges);

        public void CreateCompany(Company company);

        public List<Company> GetByIds(IEnumerable<Guid> ids);
    
        public void DeleteCompany(Company company);
    }
}
