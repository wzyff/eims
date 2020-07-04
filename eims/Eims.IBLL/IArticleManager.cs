using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IArticleManager : IBaseManager<ArticleDto>
    {
        Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int ps, int pi, string key = null);
        Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int ps, int pi, int fkid);
        Task<ArticleWithStaffDto> _getOneArticleWithStaff(int id);
    }
}
