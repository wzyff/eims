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
        [Route("{staffId}/fkey"), HttpGet]
        public async Task<Result> GetSuggestByStaffId(int staffId)
        {
            return Result.Success(await manager._getPageByStaffId(10,0,staffId));
        }

        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await manager._getPageSuggestWithStaff(pageSize, pageIndex, key));
        }
    }
}