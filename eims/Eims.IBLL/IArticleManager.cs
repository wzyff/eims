using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IArticleManager : IBaseManager<ArticleDto>
    {
        Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int pageSize, int pageIndex, string key);
    }
}
