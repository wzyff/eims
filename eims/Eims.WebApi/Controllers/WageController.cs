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
        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int ps, int pi, string key)
        {
            return Result.Success(await manager._getPageWageWithStaff(ps, pi, key));
        }

        [Route("staff"), HttpGet]
        public async Task<Result> WithStaff(int ps, int pi, int fkid)
        {
            return Result.Success(await manager._getPageWageWithStaff(ps, pi, fkid));
        }

        [Route("staff/{id}"), HttpGet]
        public async Task<Result> WithStaff(int id)
        {
            return Result.Success(await manager._getOneWageWithStaff(id));
        }

        [Route("{staffId}/payroll"), HttpGet]
        public async Task<Result> GetPayrollByStaffId(int staffId)
        {
            return Result.Success(await manager._getPayrollByStaffId(staffId));
        }

        [Route("addlist"), HttpPost]
        public async Task<Result> Addlist(List<WageDto> wages)
        {
            return Result.Success(await manager._add(wages));
        }
    }
}