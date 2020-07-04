using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/suggest")]
    public class SuggestController : BaseController<SuggestDto, ISuggestManager>
    {
        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await manager._getPageSuggestWithStaff(pageSize, pageIndex, key));
        }

        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int pageSize, int pageIndex, int fkid)
        {
            return Result.Success(await manager._getPageSuggestWithStaff(pageSize, pageIndex, fkid));
        }

        [Route("staff/{id}"), HttpGet]
        public async Task<Result> WithStaff(int id)
        {
            return Result.Success(await manager._getOneSuggestWithStaff(id));
        }
    }
}