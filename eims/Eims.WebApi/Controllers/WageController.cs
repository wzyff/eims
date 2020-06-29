using Eims.BLL;
using Eims.Dto;
using Eims.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/wage")]
    public class WageController : BaseController<WageDto, WageManager>
    {
        [Route("{staffId}/fkey")]
        [HttpGet]
        public async Task<Result> GetWagesByStaffId(int staffId)
        {
            return Result.Success(await manager._getPageByStaffId(staffId));
        }
        [Route("{staffId}/payroll")]
        [HttpGet]
        public async Task<Result> GetPayrollByStaffId(int staffId)
        {
            return Result.Success(await manager._getPayrollByStaffId(staffId));
        }
    }
}