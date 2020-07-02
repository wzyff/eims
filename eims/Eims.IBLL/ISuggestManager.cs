using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface ISuggestManager : IBaseManager<SuggestDto>
    {
        Task<List<SuggestDto>> _getPageByStaffId(int id, int pageSize = 10, int pageIndex = 0);
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int pageSize, int pageIndex, string key);
    }
}
