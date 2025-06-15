using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestParameters
{
    public abstract class RequestParameters
    {
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize: value;

        }
        public int PageNumber { get; set; } = 1;
        public const int MaxPageSize = 10;
    }
}
