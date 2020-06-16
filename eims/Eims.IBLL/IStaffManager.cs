using Eims.Dto;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IStaffManager : IBaseManager<StaffDto>
    {
        Task<AccountDto> _login(int id, string password);
    }
}
