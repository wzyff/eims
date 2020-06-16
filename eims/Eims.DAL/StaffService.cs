using Eims.IDAL;
using Eims.Models;

namespace Eims.DAL
{
    public class StaffService : BaseService<Staff>, IStaffService
    {
        public StaffService()
            : base(new EimsContext())
        {
        }
    }
}
