using Eims.Dto;
using Eims.IBLL;
using Eims.WebApi.Core;
using Eims.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix(prefix: "api/public")]
    public class PublicController : ApiController
    {
        [Dependency]
        public IStaffManager staffManager { get; set; }
        [Dependency]
        public IArticleManager articleManager { get; set; }
        [Dependency]
        public ISuggestManager suggestManager { get; set; }

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

        [Route("article"), HttpGet]
        public async Task<Result> article(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await articleManager._getPage(pageSize, pageIndex, key));
        }

        [Route("suggest"), HttpGet]
        public async Task<Result> suggest(int pageSize, int pageIndex, string key)
        {
            return Result.Success(await suggestManager._getPage(pageSize, pageIndex, key));
        }
    }
}