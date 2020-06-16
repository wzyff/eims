using Eims.IDAL;
using Eims.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Eims.DAL
{
    public class BaseService<T> : IBaseService<T>, IDisposable where T : class, new()
    {
        private readonly EimsContext _db;

        public BaseService(EimsContext db)
        {
            _db = db;
        }

        public async Task<int> InsertAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Set<T>().Add(model);
            if (saved) return await Save();
            else return -1;//-2，-1，0，>0
        }

        public async Task<int> DeleteAsync(int id, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            var t = _db.Set<T>().Find(id);
            _db.Entry(t).State = EntityState.Deleted;
            if (saved) return await Save();
            else return -1;

        }

        public async Task<int> UpdateAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            if (saved) return await Save();
            else return -1;
        }

        public async Task<int> Save()
        {
            try
            {
                int i = await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
                return i;
            }
            catch { return -2; }
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsNoTracking();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
