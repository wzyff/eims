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
    public class StaffManager : IStaffManager
    {
        [Dependency]
        public IStaffService staffService { get; set; }

        public async Task<int> _add(StaffDto staffDto)
        {
            return await staffService.InsertAsync(new Models.Staff()
            {
                Address = staffDto.Address,
                Birthday = staffDto.Birthday,
                EducationLevel = staffDto.EducationLevel,
                Email = staffDto.Email,
                GraduatedSchool = staffDto.GraduatedSchool,
                HealthStatus = staffDto.HealthStatus,
                Hometown = staffDto.Hometown,
                Id = staffDto.Id,
                IDcard = staffDto.IDcard,
                MaritalStatus = staffDto.MaritalStatus,
                Name = staffDto.Name,
                Password = staffDto.Password,
                Phone = staffDto.Phone,
                RoleId = staffDto.RoleId,
                PoliticalStatus = staffDto.PoliticalStatus,
                Sex = staffDto.Sex,
                WorkingState = staffDto.WorkingState
            });
        }

        public async Task<int> _del(int id)
        {
            return await staffService.DeleteAsync(id);
        }

        public async Task<int> _edit(StaffDto staffDto)
        {
            return await staffService.UpdateAsync(new Models.Staff()
            {
                Address = staffDto.Address,
                Birthday = staffDto.Birthday,
                EducationLevel = staffDto.EducationLevel,
                Email = staffDto.Email,
                GraduatedSchool = staffDto.GraduatedSchool,
                HealthStatus = staffDto.HealthStatus,
                Hometown = staffDto.Hometown,
                Id = staffDto.Id,
                IDcard = staffDto.IDcard,
                MaritalStatus = staffDto.MaritalStatus,
                Name = staffDto.Name,
                Password = staffDto.Password,
                Phone = staffDto.Phone,
                RoleId = staffDto.RoleId,
                PoliticalStatus = staffDto.PoliticalStatus,
                Sex = staffDto.Sex,
                WorkingState = staffDto.WorkingState
            });
        }

        public async Task<List<StaffDto>> _getAll()
        {
            return await staffService.GetAll().Select(m => new StaffDto()
            {
                Address = m.Address,
                Birthday = m.Birthday,
                EducationLevel = m.EducationLevel,
                Email = m.Email,
                GraduatedSchool = m.GraduatedSchool,
                HealthStatus = m.HealthStatus,
                Hometown = m.Hometown,
                Id = m.Id,
                IDcard = m.IDcard,
                MaritalStatus = m.MaritalStatus,
                Name = m.Name,
                Password = m.Password,
                Phone = m.Phone,
                RoleId = m.RoleId,
                PoliticalStatus = m.PoliticalStatus,
                Sex = m.Sex,
                WorkingState = m.WorkingState
            }).ToListAsync();
        }

        public async Task<List<StaffDto>> _getPage(int pageSize, int pageIndex, string key = null)
        {
            IQueryable<Models.Staff> query;
            if (key != null && key != "")
                query = staffService.GetAll().Where(m => m.Name.Contains(key) || m.IDcard == key);
            else
                query = staffService.GetAll();
            return await query.OrderBy(m => m.Id).Skip(pageSize * pageIndex).Take(pageSize).Select(m => new StaffDto()
            {
                Address = m.Address,
                Birthday = m.Birthday,
                EducationLevel = m.EducationLevel,
                Email = m.Email,
                GraduatedSchool = m.GraduatedSchool,
                HealthStatus = m.HealthStatus,
                Hometown = m.Hometown,
                Id = m.Id,
                IDcard = m.IDcard,
                MaritalStatus = m.MaritalStatus,
                Name = m.Name,
                Password = m.Password,
                Phone = m.Phone,
                RoleId = m.RoleId,
                PoliticalStatus = m.PoliticalStatus,
                Sex = m.Sex,
                WorkingState = m.WorkingState
            }).ToListAsync();
        }

        public async Task<AccountDto> _login(int id, string password)
        {
            var staff = await staffService.GetAll().FirstOrDefaultAsync(m => m.Id == id && m.Password == password);
            if (staff == null) return null;
            return new AccountDto()
            {
                Id = staff.Id,
                RoleId = staff.RoleId,
            };
        }

        public async Task<StaffDto> _getOne(int id)
        {
            Staff staff = await staffService.GetAll().FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null) return null;
            return new StaffDto()
            {
                Address = staff.Address,
                Birthday = staff.Birthday,
                EducationLevel = staff.EducationLevel,
                Email = staff.Email,
                GraduatedSchool = staff.GraduatedSchool,
                HealthStatus = staff.HealthStatus,
                Hometown = staff.Hometown,
                Id = staff.Id,
                IDcard = staff.IDcard,
                MaritalStatus = staff.MaritalStatus,
                Name = staff.Name,
                Password = staff.Password,
                Phone = staff.Phone,
                RoleId = staff.RoleId,
                PoliticalStatus = staff.PoliticalStatus,
                Sex = staff.Sex,
                WorkingState = staff.WorkingState
            };
        }
    }
}
