using Eims.IDAL;
using Eims.Models;

namespace Eims.DAL
{
    public class WageService : BaseService<Wage>, IWageService
    {
        public WageService()
            : base(new EimsContext())
        {
        }
    }
}
