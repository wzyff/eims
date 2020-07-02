using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/article")]
    public class ArticleController : BaseController<ArticleDto, IArticleManager>
    {
        [Route("staff"),HttpGet]
        public async Task<Result> WithStaff(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await manager._getPageArticleWithStaff(pageSize, pageIndex, key));
        }
    }
}