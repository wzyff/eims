using Eims.BLL;
using Eims.DAL;
using Eims.IBLL;
using Eims.IDAL;
using Unity;

namespace Eims.Core
{

    public partial class RegisterTypes
    {
        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void Partial(IUnityContainer container)
        {
            container.RegisterType<IAttendanceManager, AttendanceManager>();
            container.RegisterType<IAttendanceService, AttendanceService>();
            container.RegisterType<IArticleManager, ArticleManager>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IStaffManager, StaffManager>();
            container.RegisterType<IStaffService, StaffService>();
            container.RegisterType<ISuggestManager, SuggestManager>();
            container.RegisterType<ISuggestService, SuggestService>();
            container.RegisterType<IWageManager, WageManager>();
            container.RegisterType<IWageService, WageService>();
        }
    }
}