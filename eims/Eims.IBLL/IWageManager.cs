using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IWageManager : IBaseManager<WageDto>
    {
        Task<List<WageDto>> _getPageByStaffId(int staffId, int pageSize = 10, int pageIndex = 0);
        Task<List<PayrollDto>> _getPayrollByStaffId(int staffId);
    }
}
