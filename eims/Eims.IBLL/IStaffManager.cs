using Eims.Dto;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IStaffManager : IBaseManager<StaffDto>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<AccountDto> _login(int id, string password);
    }
}
