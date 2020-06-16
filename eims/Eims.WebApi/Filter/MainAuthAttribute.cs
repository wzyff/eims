using Eims.WebApi.Core;
using Eims.WebApi.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Eims.WebApi.Filter
{
    public class MainAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool RoleValidation { get; set; } = false;//是否开启权限验证

        public bool AllowMultiple => throw new NotImplementedException();

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            //获取request->headers->token
            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("token", out headers))
            {
                //解密token为键值对
                Dictionary<string, object> keyValues = JwtTools.Decode(headers.First());
                int id = Convert.ToInt32(keyValues["Id"].ToString());
                int roleId = Convert.ToInt32(keyValues["RoleId"].ToString());
                //将解密内容存入user->identiey
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(id, roleId);
                //验证类别
                if (RoleValidation == false || roleId == 0)
                {
                    return await continuation();
                }
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}