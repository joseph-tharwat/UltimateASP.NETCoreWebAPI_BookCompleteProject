using Shared.DTOs;

namespace Service.Contract
{
    public interface IEmployeeService
    {
        public EmployeeDto GetEmployee(Guid id, bool trackChanges);
    }
}
