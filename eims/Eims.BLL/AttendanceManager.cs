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
    public class AttendanceManager : IAttendanceManager
    {
        [Dependency]
        public IAttendanceService attendanceService { get; set; }

        public async Task<List<AttendanceDto>> _getAll(string key)
        {
            IQueryable<Models.Attendance> query;
            if (key != null && key != "")
                query = attendanceService.GetAll().Where(m => m.Name.Contains(key));
            else
                query = attendanceService.GetAll();
            return await query.Select(m => new AttendanceDto()
            {
                Id = m.Id,
                Name = m.Name,
                Money = m.Money,
                Remarks = m.Remarks
            }).ToListAsync();
        }

        public async Task<int> _add(AttendanceDto attendance)
        {
            return await attendanceService.InsertAsync(new Attendance()
            {
                Money = attendance.Money,
                Name = attendance.Name,
                Remarks = attendance.Remarks
            });
        }

        public async Task<int> _edit(AttendanceDto attendance)
        {
            return await attendanceService.UpdateAsync(new Attendance()
            {
                Id = attendance.Id,
                Name = attendance.Name,
                Money = attendance.Money,
                Remarks = attendance.Remarks
            });
        }

        public async Task<int> _del(int id)
        {
            return await attendanceService.DeleteAsync(id);
        }

        public async Task<List<AttendanceDto>> _getPage(int pageSize, int pageIndex, string key)
        {
            IQueryable<Models.Attendance> query;
            if (key != null && key != "")
                query = attendanceService.GetAll().Where(m => m.Name.Contains(key));
            else
                query = attendanceService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new AttendanceDto()
            {
                Id = m.Id,
                Name = m.Name,
                Money = m.Money,
                Remarks = m.Remarks
            }).ToListAsync();
        }

        public async Task<AttendanceDto> _getOne(int id)
        {
            Attendance attendance = await attendanceService.GetAll().FirstOrDefaultAsync(m => m.Id == id);
            return new AttendanceDto()
            {
                Id = attendance.Id,
                Name = attendance.Name,
                Money = attendance.Money,
                Remarks = attendance.Remarks
            };
        }

        public async Task<int> _getRowCount(string key = null)
        {
            IQueryable<Models.Attendance> query;
            if (key != null && key != "")
                query = attendanceService.GetAll().Where(m => m.Name.Contains(key));
            else
                query = attendanceService.GetAll();
            return await query.CountAsync();
        }

        public async Task<int> _add(List<AttendanceDto> models)
        {
            foreach (AttendanceDto model in models)
            {
                await attendanceService.InsertAsync(new Attendance()
                {
                    Money = model.Money,
                    Name = model.Name,
                    Remarks = model.Remarks
                }, false);
            }
            return await attendanceService.Save();
        }
    }
}
