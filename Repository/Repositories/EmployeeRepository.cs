using Contracts.IRepositoy;
using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository:RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context): base(context)
        {
            
        }

        public Employee GetEmployee(Guid id, bool trackChanges)
        {
            Employee employee = FindByCondition(e => e.Id == id, trackChanges).FirstOrDefault();
            return employee;
        }

        public PagedList<Employee> GetEmployees(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters)
        {
            IEnumerable<Employee> employees = FindByCondition(e => e.CompanyId == companyId, trackChanges);
            return PagedList<Employee>.ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
        }


        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }
    }
}
