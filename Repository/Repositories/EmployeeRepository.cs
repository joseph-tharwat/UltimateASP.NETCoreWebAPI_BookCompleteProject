using Contracts.IRepositoy;
using Entities.Models;
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
            return FindByCondition(e => e.Id == id, trackChanges).FirstOrDefault();
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }
    }
}
