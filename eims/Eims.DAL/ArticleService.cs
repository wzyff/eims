using Eims.IDAL;
using Eims.Models;

namespace Eims.DAL
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        public ArticleService()
            : base(new EimsContext())
        {
        }
    }
}
