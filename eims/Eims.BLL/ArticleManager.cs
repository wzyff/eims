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
        [Dependency]
        public IStaffService staffService { get; set; }

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

        public async Task<List<ArticleDto>> _getAll(string key)
        {
            IQueryable<Models.Article> query;
            if (key != null && key != "")
                query = articleService.GetAll().Where(m => m.Title.Contains(key));
            else
                query = articleService.GetAll();
            return await query.Select(m => new ArticleDto()
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

        public async Task<List<ArticleDto>> _getPage(int ps, int pi, string key)
        {
            IQueryable<Models.Article> query;
            if (key != null && key != "")
                query = articleService.GetAll().Where(m => m.Title.Contains(key));
            else
                query = articleService.GetAll();
            return await query.OrderBy(m => m.CreateTime).Skip(ps * pi).Take(ps).Select(m => new ArticleDto()
            {
                Id = m.Id,
                Content = m.Content,
                CreateTime = m.CreateTime,
                StaffId = m.StaffId,
                Title = m.Title
            }).ToListAsync();
        }

        public async Task<int> _getRowCount(string key = null)
        {
            IQueryable<Models.Article> query;
            if (key != null && key != "")
                query = articleService.GetAll().Where(m => m.Title.Contains(key));
            else
                query = articleService.GetAll();
            return await query.CountAsync();
        }

        public async Task<int> _add(List<ArticleDto> models)
        {
            foreach (ArticleDto model in models)
            {
                await articleService.InsertAsync(new Article()
                {
                    Content = model.Content,
                    CreateTime = model.CreateTime,
                    Id = model.Id,
                    StaffId = model.StaffId,
                    Title = model.Title
                }, false);
            }
            return await articleService.Save();
        }

        public async Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int ps, int pi, string key = null)
        {
            var staffs = await staffService.GetAll().ToListAsync();
            var articles = await articleService.GetAll().ToListAsync();
            if (key != null && key != "")
                articles = await articleService.GetAll().Where(m => m.Title.Contains(key)).ToListAsync();
            return articles.AsQueryable().OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new ArticleWithStaffDto()
            {
                Id = a.Id,
                StaffId = a.StaffId,
                Content = a.Content,
                CreateTime = a.CreateTime,
                Title = a.Title,
                Staff_Name = b.Name
            }).ToList();
        }

        public async Task<List<ArticleWithStaffDto>> _getPageArticleWithStaff(int ps, int pi, int fkid)
        {
            var staffs = await staffService.GetAll().ToListAsync();
            var articles = await articleService.GetAll().Where(m => m.StaffId == fkid).ToListAsync();
            return articles.AsQueryable().OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new ArticleWithStaffDto()
            {
                Id = a.Id,
                StaffId = a.StaffId,
                Content = a.Content,
                CreateTime = a.CreateTime,
                Title = a.Title,
                Staff_Name = b.Name
            }).ToList();
        }

        public async Task<ArticleWithStaffDto> _getOneArticleWithStaff(int id)
        {
            var staffs = await staffService.GetAll().ToListAsync();
            var article = await articleService.GetAll().Where(m => m.Id == id).ToListAsync();
            return article.AsQueryable().Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new ArticleWithStaffDto()
            {
                Id = a.Id,
                StaffId = a.StaffId,
                Content = a.Content,
                CreateTime = a.CreateTime,
                Title = a.Title,
                Staff_Name = b.Name
            }).FirstOrDefault();
        }
    }
}
