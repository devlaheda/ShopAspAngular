using System.Collections.Generic;

namespace API.Helpers
{
    public class PaginationWrapper<T> where T: class
    {
        public PaginationWrapper(int pageSize, int pageIndex, int count, IReadOnlyList<T> products)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Products = products;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Products { get; set; }
    }
}