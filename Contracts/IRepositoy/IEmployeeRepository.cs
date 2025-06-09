using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositoy
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(Guid id, bool trackChanges);
        public PagedList<Employee> GetEmployees(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters);
        public void CreateEmployee(Employee employee);

    }
}
