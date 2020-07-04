using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface ISuggestManager : IBaseManager<SuggestDto>
    {
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int pageSize, int pageIndex, string key = null);
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int pageSize, int pageIndex, int fkid);
        Task<SuggestWithStaffDto> _getOneSuggestWithStaff(int id);

        Task<List<SuggestDto>> _getPageByStaffId(int pageSize, int pageIndex, int id);
    }
}
