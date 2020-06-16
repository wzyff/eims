using Eims.Dto;
using Eims.IBLL;
using System.Web.Http;

namespace Eims.WebApi.Controllers
{
    [RoutePrefix("api/attendance")]
    public class AttendanceController : BaseController<AttendanceDto, IAttendanceManager>
    {
    }
}