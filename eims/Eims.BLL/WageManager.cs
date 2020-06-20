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
    public class WageManager : IWageManager
    {
        [Dependency]
        public IWageService wageService { get; set; }

        public async Task<int> _add(WageDto model)
        {
            return await wageService.InsertAsync(new Wage()
            {
                AttendanceMoney = model.AttendanceMoney,
                Id = model.Id,
                AttendanceName = model.AttendanceName,
                Remark = model.Remark,
                StaffId = model.StaffId,
                Time = model.Time,
                Times = model.Times
            });
        }

        public async Task<int> _del(int id)
        {
            return await wageService.DeleteAsync(id);
        }

        public async Task<int> _edit(WageDto model)
        {
            return await wageService.UpdateAsync(new Wage()
            {
                AttendanceMoney = model.AttendanceMoney,
                Id = model.Id,
                AttendanceName = model.AttendanceName,
                Remark = model.Remark,
                StaffId = model.StaffId,
                Time = model.Time,
                Times = model.Times
            });
        }

        public async Task<List<WageDto>> _getAll()
        {
            return await wageService.GetAll().Select(m => new WageDto()
            {
                AttendanceMoney = m.AttendanceMoney,
                Id = m.Id,
                AttendanceName = m.AttendanceName,
                Remark = m.Remark,
                StaffId = m.StaffId,
                Time = m.Time,
                Times = m.Times
            }).ToListAsync();
        }

        public async Task<List<PayrollDto>> _getPayrollByStaffId(int staffId)
        {
            IQueryable<Wage> query = wageService.GetAll().Where(m => m.StaffId == staffId);
            return await query.GroupBy(m => new { m.StaffId, m.AttendanceName, m.AttendanceMoney }).Select(m => new PayrollDto()
            {
                StaffId = (int)m.Key.StaffId,
                AttenName = m.Key.AttendanceName,
                AttenMoney = (float)m.Key.AttendanceMoney,
                AttenTimes = m.Sum(i => (int)i.Times)
            }).ToListAsync();
        }

        public async Task<WageDto> _getOne(int id)
        {
            Wage m = await wageService.GetAll().FirstOrDefaultAsync(a => a.Id == id);
            return new WageDto()
            {
                AttendanceMoney = m.AttendanceMoney,
                Id = m.Id,
                AttendanceName = m.AttendanceName,
                Remark = m.Remark,
                StaffId = m.StaffId,
                Time = m.Time,
                Times = m.Times
            };
        }

        public async Task<List<WageDto>> _getPage(int pageSize, int pageIndex, string key)
        {
            IQueryable<Models.Wage> query;
            if (key != null && key != "")
                query = wageService.GetAll().Where(m => m.AttendanceName.Contains(key));
            else
                query = wageService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new WageDto()
            {
                AttendanceMoney = m.AttendanceMoney,
                Id = m.Id,
                AttendanceName = m.AttendanceName,
                Remark = m.Remark,
                StaffId = m.StaffId,
                Time = m.Time,
                Times = m.Times
            }).ToListAsync();
        }

        public async Task<List<WageDto>> _getPageByStaffId(int staffId, int pageSize = 10, int pageIndex = 0)
        {
            return await wageService.GetAll().Where(m => m.StaffId == staffId).OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new WageDto()
            {
                AttendanceMoney = m.AttendanceMoney,
                Id = m.Id,
                AttendanceName = m.AttendanceName,
                Remark = m.Remark,
                StaffId = m.StaffId,
                Time = m.Time,
                Times = m.Times
            }).ToListAsync();
        }

        public async Task<int> _getRowCount(string key = null)
        {
            IQueryable<Models.Wage> query;
            if (key != null && key != "")
                query = wageService.GetAll().Where(m => m.AttendanceName.Contains(key));
            else
                query = wageService.GetAll();
            return await query.CountAsync();
        }
    }
}
