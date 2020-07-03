using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eims.IBLL
{
    public interface IBaseManager<T>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页长度</param>
        /// <param name="pageIndex">页码(从0开始)</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        Task<List<T>> _getPage(int pageSize, int pageIndex, string key = null);
        /// <summary>
        /// 不分页查询
        /// </summary>
        /// <returns></returns>
        Task<List<T>> _getAll(string key = null);
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> _getOne(int id);
        /// <summary>
        /// 获取总行数
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        Task<int> _getRowCount(string key = null);
        /// <summary>
        /// 添加一條數據
        /// </summary>
        /// <param name="model">数据对象</param>
        /// <returns></returns>
        Task<int> _add(T model);
        /// <summary>
        /// 添加多條數據
        /// </summary>
        /// <param name="models">数据对象List</param>
        /// <returns></returns>
        Task<int> _add(List<T> models);
        /// <summary>
        /// 編輯一条数据
        /// </summary>
        /// <param name="model">数据对象</param>
        /// <returns></returns>
        Task<int> _edit(T model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<int> _del(int id);
    }
}
