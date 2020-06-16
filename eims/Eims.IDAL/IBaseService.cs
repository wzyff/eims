using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eims.IDAL
{
    public interface IBaseService<T> : IDisposable where T : class
    {
        Task<int> InsertAsync(T model, bool saved = true);
        Task<int> UpdateAsync(T model, bool saved = true);
        Task<int> DeleteAsync(int id, bool saved = true);
        Task<int> Save();
        IQueryable<T> GetAll();
    }
}
