using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IArticleManager : IBaseManager<ArticleDto>
    {
        /// <summary>
        /// 分页联表查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int pageSize, int pageIndex, string key=null);
    }
}
