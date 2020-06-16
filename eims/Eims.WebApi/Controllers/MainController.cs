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
        public async Task<Result> login(LoginViewModel model)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MainAuth, Route("module"), HttpGet]
        public List<object> module()
        {
            UserIdentity i = (UserIdentity)User.Identity;
            if (i.RoleId != 0)
                return new List<object>()
                {
                    new
                    {
                        parent="个人信息",
                        action=new object[]
                        {
                            new { name= "个人信息查看",href="mystaff.html" },
                            new { name= "个人信息修改",href="editstaff.html" }
                        }
                    },
                    new
                    {
                        parent="我的工资",
                        action=new object[]
                        {
                            new { name= "本月工资条",href="mywage.html" }
                        }
                    },
                    new
                    {
                        parent="公司新闻",
                        action=new object[]
                        {
                            new { name= "所有新闻",href="article.html" }
                        }
                    },
                    new
                    {
                        parent="员工反馈",
                        action=new object[]
                        {
                            new { name= "我的反馈",href="mysuggest.html" },
                            new { name= "添加反馈",href="addsuggest.html" }
                        }
                    }
                };
            return new List<object>()
            {
                new
                {
                    parent="员工信息管理",
                    action=new object[]
                    {
                        new { name= "员工信息",href="staff.html" }
                    }
                },
                new
                {
                    parent="员工工资管理",
                    action=new object[]
                    {
                        new { name= "员工本月工资",href="index.html" },
                        new { name= "员工奖惩",href="index.html" },
                        new { name= "添加员工奖惩",href="index.html" }
                    }
                },
                new
                {
                    parent="公司新闻管理",
                    action=new object[]
                    {
                        new { name= "所有新闻",href="index.html" },
                        new { name= "发布新闻",href="index.html" }
                    }
                },
                new
                {
                    parent="员工反馈管理",
                    action=new object[]
                    {
                        new { name= "员工反馈",href="suggest.html" },
                        new { name= "添加回复",href="addsuggest.html" }
                    }
                }
            };
        }
    }
}