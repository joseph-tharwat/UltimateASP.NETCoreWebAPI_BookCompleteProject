using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Logger
{
    public interface ILoggerService
    {
        public void LogInfo(string message);
        public void LogDebuge(string message);
    }
}
