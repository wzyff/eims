using Eims.BLL;
using Eims.Dto;
using Eims.WebApi.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/wage")]
    public class WageController : BaseController<WageDto, WageManager>
    {
        [Route("{staffId}/fkey"),HttpGet]
        public async Task<Result> GetWagesByStaffId(int staffId)
        {
            return Result.Success(await manager._getPageByStaffId(staffId));
        }
        [Route("{staffId}/payroll"), HttpGet]
        public async Task<Result> GetPayrollByStaffId(int staffId)
        {
            return Result.Success(await manager._getPayrollByStaffId(staffId));
        }

        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await manager._getPageWageWithStaff(pageSize, pageIndex, key));
        }
    }
}