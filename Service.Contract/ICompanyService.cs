using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICompanyService
    {
        public List<CompanyDto> GetCompanies();
        public CompanyDto CreateCompany(CompanyForCreationDto company);
        public CompanyDto GetCompanyById(Guid id, bool trackChanges);
        public List<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        public void DeleteCompany(Guid companyId);

    }
}
