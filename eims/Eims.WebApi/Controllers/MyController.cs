using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Filter;
using Eims.WebApi.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace Eims.WebApi.Controllers
{
    /// <summary>
    /// 非管理员controller
    /// </summary>
    [RoutePrefix("api/my")]
    [MainAuth]
    public class MyController : ApiController
    {
        [Dependency]
        public IStaffManager staffManager { get; set; }
        [Dependency]
        public IWageManager wageManager { get; set; }
        [Dependency]
        public ISuggestManager suggestManager { get; set; }

        [HttpGet, Route("payroll")]
        public async Task<List<PayrollDto>> Payroll()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return await wageManager._getPayrollByStaffId(my.Id);
        }

        [HttpGet, Route("wage")]
        public async Task<List<WageDto>> Wage()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return await wageManager._getPageByStaffId(my.Id);
        }

        [HttpGet, Route("Info")]
        public async Task<StaffDto> Info()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return await staffManager._getOne(my.Id);
        }

        [HttpPost, Route("InfoEdit")]
        public async Task<int> InfoEdit(StaffDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.Id = my.Id;
            return await staffManager._edit(model);
        }

        [HttpGet, Route("Suggest")]
        public async Task<List<SuggestDto>> Suggest()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return await suggestManager._getPageByStaffId(my.Id);
        }

        [HttpPost, Route("SuggestAdd")]
        public async Task<int> SuggesrAdd(SuggestDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.StaffId = my.Id;
            return await suggestManager._add(model);
        }
    }
}