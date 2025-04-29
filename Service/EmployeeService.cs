using Contracts.IRepositoy;
using Contracts.Logger;
using Service.Contract;

namespace Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerService _logger;
        public EmployeeService(IRepositoryManager repositoryManager, ILoggerService loggerService)
        {
            _repository = repositoryManager;
            _logger = loggerService;
        }
    }
}
