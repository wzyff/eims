using Eims.IDAL;
using Eims.Models;

namespace Eims.DAL
{
    public class AttendanceService : BaseService<Attendance>, IAttendanceService
    {
        public AttendanceService()
            : base(new EimsContext())
        {
        }
    }
}
