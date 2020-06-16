using Eims.Dto;
using Eims.IBLL;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/article")]
    public class ArticleController : BaseController<ArticleDto, IArticleManager>
    {
    }
}