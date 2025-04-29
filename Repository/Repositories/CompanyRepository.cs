using Contracts.IRepositoy;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context): base(context)
        {
            
        }

        public List<Company> GetCompanies()
        {
            return FindAll(false).ToList();
        }
    }
}
