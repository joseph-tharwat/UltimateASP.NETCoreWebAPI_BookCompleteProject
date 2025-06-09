using Contracts.IRepositoy;
using Entities.Models;
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

        public List<Employee> GetEmployees(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters)
        {
            List<Employee> employees = FindByCondition(e => e.CompanyId == companyId, trackChanges)
                .Skip(employeeParameters.PageSize * (employeeParameters.PageNumber-1))
                .Take(employeeParameters.PageSize)
                .ToList();
            return employees;
        }


        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }
    }
}
