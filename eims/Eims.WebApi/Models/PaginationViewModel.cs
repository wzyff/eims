using System.Collections.Generic;

namespace Eims.WebApi.Models
{
    public class PaginationViewModel<T>
    {
        public int PageIndex { get; set; }
        public int RowCount { get; set; }
        public List<T> RowList { get; set; }
    }
}