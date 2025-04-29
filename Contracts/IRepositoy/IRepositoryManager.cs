using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositoy
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        ICompanyRepository Company { get; }
        void save();
    }
}
