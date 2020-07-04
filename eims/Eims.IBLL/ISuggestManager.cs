using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface ISuggestManager : IBaseManager<SuggestDto>
    {
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int ps, int pi, string key = null);
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int ps, int pi, int fkid);
        Task<SuggestWithStaffDto> _getOneSuggestWithStaff(int id);

        Task<List<SuggestDto>> _getPageByStaffId(int ps, int pi, int id);
    }
}
