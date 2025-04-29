using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IServiceManager
    {
        IEmployeeService EmployeeService { get; }
        ICompanyService CompanyService { get; }
    }
}
