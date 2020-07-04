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
        [Dependency]
        public IStaffService StaffService { get; set; }

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

        public async Task<List<WageDto>> _getAll(string key)
        {
            IQueryable<Models.Wage> query;
            if (key != null && key != "")
                query = wageService.GetAll().Where(m => m.AttendanceName.Contains(key));
            else
                query = wageService.GetAll();
            return await query.Select(m => new WageDto()
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

        public async Task<List<WageDto>> _getPage(int ps, int pi, string key)
        {
            IQueryable<Models.Wage> query;
            if (key != null && key != "")
                query = wageService.GetAll().Where(m => m.AttendanceName.Contains(key));
            else
                query = wageService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Select(m => new WageDto()
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

        public async Task<List<WageDto>> _getPageByStaffId(int staffId, int ps = 10, int pi = 0)
        {
            return await wageService.GetAll().Where(m => m.StaffId == staffId).OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Select(m => new WageDto()
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

        public async Task<int> _add(List<WageDto> models)
        {
            foreach (WageDto model in models)
            {
                await wageService.InsertAsync(new Wage()
                {
                    AttendanceMoney = model.AttendanceMoney,
                    Id = model.Id,
                    AttendanceName = model.AttendanceName,
                    Remark = model.Remark,
                    StaffId = model.StaffId,
                    Time = model.Time,
                    Times = model.Times
                }, false);
            }
            return await wageService.Save();
        }

        public async Task<List<WageWithStaffDto>> _getPageWageWithStaff(int ps, int pi, string key)
        {
            var staffs = await StaffService.GetAll().ToListAsync();
            var wages = await wageService.GetAll().ToListAsync();
            if (key != null && key != "")
                wages = await wageService.GetAll().Where(m => m.AttendanceName.Contains(key)).ToListAsync();
            return wages.AsQueryable().OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new WageWithStaffDto()
            {
                AttendanceMoney = a.AttendanceMoney,
                Id = a.Id,
                AttendanceName = a.AttendanceName,
                Remark = a.Remark,
                StaffId = a.StaffId,
                Time = a.Time,
                Times = a.Times,
                Staff_Name = b.Name
            }).ToList();
        }

        public async Task<List<WageWithStaffDto>> _getPageWageWithStaff(int ps, int pi, int fkid)
        {
            var staffs = await StaffService.GetAll().ToListAsync();
            var wages = await wageService.GetAll().Where(m => m.StaffId == fkid).ToListAsync();
            return wages.AsQueryable().OrderBy(m => m.Id).Skip(ps * pi).Take(ps).Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new WageWithStaffDto()
            {
                AttendanceMoney = a.AttendanceMoney,
                Id = a.Id,
                AttendanceName = a.AttendanceName,
                Remark = a.Remark,
                StaffId = a.StaffId,
                Time = a.Time,
                Times = a.Times,
                Staff_Name = b.Name
            }).ToList();
        }

        public async Task<WageWithStaffDto> _getOneWageWithStaff(int id)
        {
            var staffs = await StaffService.GetAll().ToListAsync();
            var wages = await wageService.GetAll().Where(m => m.Id == id).ToListAsync();
            return wages.AsQueryable().Join(staffs, a => a.StaffId, b => b.Id, (a, b) => new WageWithStaffDto()
            {
                AttendanceMoney = a.AttendanceMoney,
                Id = a.Id,
                AttendanceName = a.AttendanceName,
                Remark = a.Remark,
                StaffId = a.StaffId,
                Time = a.Time,
                Times = a.Times,
                Staff_Name = b.Name
            }).FirstOrDefault();
        }
    }
}
