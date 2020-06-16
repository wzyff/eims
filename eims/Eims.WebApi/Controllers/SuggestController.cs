using Eims.Dto;
using Eims.IBLL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/suggest")]
    public class SuggestController : BaseController<SuggestDto, ISuggestManager>
    {
        [Route("{staffId}/fkey")]
        [HttpGet]
        public async Task<List<SuggestDto>> GetSuggestByStaffId(int staffId)
        {
            return await manager._getPageByStaffId(staffId);
        }
    }
}