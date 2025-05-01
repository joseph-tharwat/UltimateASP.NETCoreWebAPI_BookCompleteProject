using AutoMapper;
using Contracts.IRepositoy;
using Contracts.Logger;
using Service.Contract;
using Shared.DTOs;

namespace Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repositoryManager, ILoggerService loggerService, IMapper mapper)
        {
            _repository = repositoryManager;
            _logger = loggerService;
            _mapper = mapper;
        }

        public EmployeeDto GetEmployee(Guid id, bool trackChanges)
        {
            if(id == null)
                throw new ArgumentNullException("id");

            _logger.LogInfo("GetEmployee: " + id.ToString());

            var employeeEntity = _repository.Employee.GetEmployee(id, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeDto;
        }
    }
}
