﻿using Contracts.IRepositoy;
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

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public List<Company> GetByIds(IEnumerable<Guid> ids)
        {
            return FindByCondition(c=> ids.Contains(c.Id), false).ToList();
        }

        public Company GetCompanyById(Guid id, bool trackChanges)
        {
            return FindByCondition(x => x.Id==id, false).FirstOrDefault();
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }
    }
}
