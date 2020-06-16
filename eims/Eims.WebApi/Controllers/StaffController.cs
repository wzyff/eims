using Eims.Dto;
using Eims.IBLL;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/staff")]
    public class StaffController : BaseController<StaffDto, IStaffManager>
    {
    }
}