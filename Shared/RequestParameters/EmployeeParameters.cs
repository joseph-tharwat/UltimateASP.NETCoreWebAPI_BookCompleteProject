using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestParameters
{
    public class EmployeeParameters:RequestParameters
    {
        public string searchTerm { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
    }
}
