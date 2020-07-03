using Eims.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IWageManager : IBaseManager<WageDto>
    {
        /// <summary>
        /// 外键分页查询
        /// </summary>
        /// <param name="staffId">staffid</param>
        /// <param name="pageSize">页行数</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        Task<List<WageDto>> _getPageByStaffId( int pageSize, int pageIndex, int staffId);
        /// <summary>
        /// 获取历史总工资单
        /// </summary>
        /// <param name="staffId">staff</param>
        /// <returns></returns>
        Task<List<PayrollDto>> _getPayrollByStaffId(int staffId);
    }
}
