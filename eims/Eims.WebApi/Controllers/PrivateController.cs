using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Filter;
using Eims.WebApi.Models;
using Eims.WebApi.Models.Auth;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace Eims.WebApi.Controllers
{
    /// <summary>
    /// 必须登录
    /// </summary>
    [WebApiExceptionFilter, RoutePrefix("api/private"), MainAuth]
    public class PrivateController : ApiController
    {
        [Dependency]
        public IStaffManager staffManager { get; set; }
        [Dependency]
        public IWageManager wageManager { get; set; }
        [Dependency]
        public ISuggestManager suggestManager { get; set; }

        /// <summary>
        /// 获取我的历史总工资单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("payroll")]
        public async Task<Result> Payroll()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await wageManager._getPayrollByStaffId(my.Id));
        }

        /// <summary>
        /// 获取我的所有的奖惩、日工资
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("wages")]
        public async Task<Result> Wages()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await wageManager._getPageByStaffId(10, 0, my.Id));
        }

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("info")]
        public async Task<Result> Info()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await staffManager._getOne(my.Id));
        }

        /// <summary>
        /// 我的反馈
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("suggests")]
        public async Task<Result> Suggests()
        {
            UserIdentity my = (UserIdentity)User.Identity;
            return Result.Success(await suggestManager._getPageByStaffId(10, 0, my.Id));
        }

        /// <summary>
        /// 修改我的信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut, Route("editinfo")]
        public async Task<Result> EditInfo(StaffDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.Id = my.Id;
            return Result.Success(await staffManager._edit(model));
        }

        /// <summary>
        /// 添加反馈
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("addsuggest")]
        public async Task<Result> AddSuggesr(SuggestDto model)
        {
            UserIdentity my = (UserIdentity)User.Identity;
            model.StaffId = my.Id;
            return Result.Success(await suggestManager._add(model));
        }
    }
}