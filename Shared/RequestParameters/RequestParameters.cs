using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestParameters
{
    public abstract class RequestParameters
    {
        public int PageSize { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
        public const int MaxPageSize = 10;

    }
}
