using Shared.DTOs;
using Shared.RequestFeatures;
using Shared.RequestParameters;

namespace Service.Contract
{
    public interface IEmployeeService
    {
        public EmployeeDto GetEmployee(Guid id, bool trackChanges);

        public (List<EmployeeDto> employees, MetaData metaData)  GetEmployees(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters);
    }
}
