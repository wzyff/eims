using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IWageManager : IBaseManager<WageDto>
    {
        Task<List<WageWithStaffDto>> _getPageWageWithStaff(int pageSize, int pageIndex, string key);
        Task<List<WageWithStaffDto>> _getPageWageWithStaff(int pageSize, int pageIndex, int fkid);
        Task<WageWithStaffDto> _getOneWageWithStaff(int id);

        Task<List<WageDto>> _getPageByStaffId(int pageSize, int pageIndex, int staffId);
        Task<List<PayrollDto>> _getPayrollByStaffId(int staffId);
    }
}
