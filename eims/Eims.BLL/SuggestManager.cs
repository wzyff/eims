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
    public class SuggestManager : ISuggestManager
    {
        [Dependency]
        public ISuggestService suggestService { get; set; }
        public async Task<int> _add(SuggestDto model)
        {
            return await suggestService.InsertAsync(new Suggest()
            {
                Content = model.Content,
                Id = model.Id,
                Reply = model.Reply,
                ReplyTime = model.ReplyTime,
                StaffId = model.StaffId,
                SuggestTime = model.SuggestTime,
                Title = model.Title
            });
        }

        public async Task<int> _del(int id)
        {
            return await suggestService.DeleteAsync(id);
        }

        public async Task<int> _edit(SuggestDto model)
        {
            return await suggestService.UpdateAsync(new Suggest()
            {
                Content = model.Content,
                Id = model.Id,
                Reply = model.Reply,
                ReplyTime = model.ReplyTime,
                StaffId = model.StaffId,
                SuggestTime = model.SuggestTime,
                Title = model.Title
            });
        }

        public async Task<List<SuggestDto>> _getAll()
        {
            return await suggestService.GetAll().Select(m => new SuggestDto()
            {
                Content = m.Content,
                Id = m.Id,
                Reply = m.Reply,
                ReplyTime = m.ReplyTime,
                StaffId = m.StaffId,
                SuggestTime = m.SuggestTime,
                Title = m.Title
            }).ToListAsync();
        }

        public async Task<SuggestDto> _getOne(int id)
        {
            Suggest m = await suggestService.GetAll().FirstOrDefaultAsync(a => a.Id == id);
            return new SuggestDto()
            {
                Content = m.Content,
                Id = m.Id,
                Reply = m.Reply,
                ReplyTime = m.ReplyTime,
                StaffId = m.StaffId,
                SuggestTime = m.SuggestTime,
                Title = m.Title
            };
        }

        public async Task<List<SuggestDto>> _getPage(int pageSize, int pageIndex, string key)
        {
            IQueryable<Models.Suggest> query;
            if (key != null && key != "")
                query = suggestService.GetAll().Where(m => m.Title.Contains(key) || m.Content.Contains(key));
            else
                query = suggestService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new SuggestDto()
            {
                Content = m.Content,
                Id = m.Id,
                Reply = m.Reply,
                ReplyTime = m.ReplyTime,
                StaffId = m.StaffId,
                SuggestTime = m.SuggestTime,
                Title = m.Title
            }).ToListAsync();
        }

        public async Task<List<SuggestDto>> _getPageByStaffId(int staffId, int pageSize = 10, int pageIndex = 0)
        {
            return await suggestService.GetAll().Where(m => m.StaffId == staffId).OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new SuggestDto()
            {
                Content = m.Content,
                Id = m.Id,
                Reply = m.Reply,
                ReplyTime = m.ReplyTime,
                StaffId = m.StaffId,
                SuggestTime = m.SuggestTime,
                Title = m.Title
            }).ToListAsync();
        }
    }
}
