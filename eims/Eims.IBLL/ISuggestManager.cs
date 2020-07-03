using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface ISuggestManager : IBaseManager<SuggestDto>
    {
        /// <summary>
        /// 分页外键查询
        /// </summary>
        /// <param name="id">staffid</param>
        /// <param name="pageSize">页行数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        Task<List<SuggestDto>> _getPageByStaffId(int pageSize, int pageIndex, int id);
        /// <summary>
        /// 分页联表查询
        /// </summary>
        /// <param name="pageSize">页行数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        Task<List<SuggestWithStaffDto>> _getPageSuggestWithStaff(int pageSize, int pageIndex, string key = null);
    }
}
