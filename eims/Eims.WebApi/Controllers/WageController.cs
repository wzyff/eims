using Eims.BLL;
using Eims.Dto;
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
        public async Task<List<WageDto>> GetWagesByStaffId(int staffId)
        {
            return await manager._getPageByStaffId(staffId);
        }
        [Route("{staffId}/payroll")]
        [HttpGet]
        public async Task<List<PayrollDto>> GetPayrollByStaffId(int staffId)
        {
            return await manager._getPayrollByStaffId(staffId);
        }
    }
}