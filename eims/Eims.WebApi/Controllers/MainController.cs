using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Core;
using Eims.WebApi.Filter;
using Eims.WebApi.Models;
using Eims.WebApi.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix(prefix: "api/main")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MainController : ApiController
    {
        [Dependency]
        public IStaffManager staffManager { get; set; }

        /// <summary>
        /// 使用id、password登录，返回token字符串
        /// </summary>
        /// <param name="model"></param>
        /// <returns>token</returns>
        [Route("login"), HttpPost]
        public async Task<Result> login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountDto user = await staffManager._login(model.Id, model.Password);
                if (user == null)
                    return Result.Fail("账号或密码错误");
                return Result.Success(new UserViewModel()
                {
                    Token = JwtTools.Encode(new Dictionary<string, object>(){
                        { "Id",user.Id },
                        { "RoleId",user.RoleId }
                    }),
                    Id = user.Id,
                    Role = (int)user.RoleId
                });
            }
            return Result.Fail("输入不规范");
        }
    }
}