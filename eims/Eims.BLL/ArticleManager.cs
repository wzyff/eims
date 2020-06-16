using Eims.Dto;
using Eims.IBLL;
using Eims.IDAL;
using Eims.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace Eims.BLL
{
    public class ArticleManager : IArticleManager
    {
        [Dependency]
        public IArticleService articleService { get; set; }

        public async Task<int> _add(ArticleDto article)
        {
            return await articleService.InsertAsync(new Models.Article()
            {
                Content = article.Content,
                CreateTime = article.CreateTime,
                Id = article.Id,
                StaffId = article.StaffId,
                Title = article.Title
            });
        }

        public async Task<int> _del(int id)
        {
            return await articleService.DeleteAsync(id);
        }

        public async Task<int> _edit(ArticleDto article)
        {
            return await articleService.UpdateAsync(new Models.Article()
            {
                Content = article.Content,
                CreateTime = article.CreateTime,
                Id = article.Id,
                StaffId = article.StaffId,
                Title = article.Title
            });
        }

        public async Task<List<ArticleDto>> _getAll()
        {
            return await articleService.GetAll().Select(m => new ArticleDto()
            {
                Id = m.Id,
                Content = m.Content,
                CreateTime = m.CreateTime,
                StaffId = m.StaffId,
                Title = m.Title
            }).ToListAsync();
        }

        public async Task<ArticleDto> _getOne(int id)
        {
            Article m = await articleService.GetAll().FirstOrDefaultAsync(a => a.Id == id);
            return new ArticleDto()
            {
                Id = m.Id,
                Content = m.Content,
                CreateTime = m.CreateTime,
                StaffId = m.StaffId,
                Title = m.Title
            };
        }

        public async Task<List<ArticleDto>> _getPage(int pageSize, int pageIndex, string key)
        {
            IQueryable<Models.Article> query;
            if (key != null && key != "")
                query = articleService.GetAll().Where(m => m.Title.Contains(key));
            else
                query = articleService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new ArticleDto()
            {
                Id = m.Id,
                Content = m.Content,
                CreateTime = m.CreateTime,
                StaffId = m.StaffId,
                Title = m.Title
            }).ToListAsync();
        }
    }
}
