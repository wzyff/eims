using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IWageManager : IBaseManager<WageDto>
    {
        Task<List<WageWithStaffDto>> _getPageWageWithStaff(int ps, int pi, string key);
        Task<List<WageWithStaffDto>> _getPageWageWithStaff(int ps, int pi, int fkid);
        Task<WageWithStaffDto> _getOneWageWithStaff(int id);

        Task<List<WageDto>> _getPageByStaffId(int ps, int pi, int staffId);
        Task<List<PayrollDto>> _getPayrollByStaffId(int staffId);
    }
}
