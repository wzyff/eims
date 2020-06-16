using Eims.IDAL;
using Eims.Models;

namespace Eims.DAL
{
    public class SuggestService : BaseService<Suggest>, ISuggestService
    {
        public SuggestService()
            : base(new EimsContext())
        {
        }
    }
}
