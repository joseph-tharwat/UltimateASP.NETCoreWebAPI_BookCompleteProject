using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        
        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount) 
        {
            MetaData = new MetaData(pageSize, pageNumber, totalCount);
            AddRange(items); 
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> items, int pageNumber, int pageSize)
        {
            var selectedItems = items
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToList();
            return new PagedList<T>(selectedItems, pageNumber, pageSize, items.Count());
        }
    }
}
