using System.Web.Http;

namespace Eims.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //注入
            UnityConfig.RegisterComponents();
        }
    }
}
