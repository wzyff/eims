using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Filter;
using Eims.WebApi.Models;
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
        public async Task<Result> Payroll()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await wageManager._getPayrollByStaffId(my.Id));
        }

        [HttpGet, Route("wage")]
        public async Task<Result> Wage()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await wageManager._getPageByStaffId(my.Id));
        }

        [HttpGet, Route("info")]
        public async Task<Result> Info()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await staffManager._getOne(my.Id));
        }

        [HttpGet, Route("suggest")]
        public async Task<Result> Suggest()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await suggestManager._getPageByStaffId(my.Id));
        }

        [HttpPut, Route("editinfo")]
        public async Task<Result> EditInfo([FromBody]StaffDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.Id = my.Id;
            return Result.Success(await staffManager._edit(model));
        }

        [HttpPost, Route("addsuggest")]
        public async Task<Result> AddSuggesr([FromBody]SuggestDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.StaffId = my.Id;
            return Result.Success(await suggestManager._add(model));
        }
    }
}