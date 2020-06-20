using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eims.WebApi.Models
{
    public class PaginationViewModel<T> 
    {
        public int PageIndex { get; set; }
        public int RowCount { get; set; }
        public List<T> RowList { get; set; }
    }
}