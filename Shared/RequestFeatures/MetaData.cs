using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class MetaData
    {
        public int PageSize { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
        public int TotalCount { get; set; }  
        public int TotalPages { get; set; }
        public MetaData(int pageSize, int pageNumber, int totalCount)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount/(double)pageSize);
        }
        public bool HasNext()
        {
            if (PageNumber >= TotalPages)
                return false;

            return true;
        }
        public bool HasPrevious()
        {
            if (PageNumber <= 0)
                return false;

            return true;
        }

    }
}
