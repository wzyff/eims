using Eims.IBLL;
using Eims.WebApi.Filter;
using Eims.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;

namespace Eims.WebApi.Controllers
{
    // 必须登录，且是管理员
    [ MainAuth(RoleValidation = true)]
    public class BaseController<T, M> : ApiController where M : IBaseManager<T>
    {
        [Dependency]
        public M manager { get; set; }
        
        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            return Result.Success(await manager._del(id));
        }

        /// <summary>
        /// 分页查询获取
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<Result> Get(int pageSize, int pageIndex, string key = null)
        {
            int rowCount = await manager._getRowCount(key);
            return Result.Success(new PaginationViewModel<T>()
            {
                PageIndex = pageIndex,
                RowCount = rowCount,
                RowList = await manager._getPage(pageSize, pageIndex, key)
            });
        }

        /// <summary>
        /// 主键获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Get(int id)
        {
            return Result.Success(await manager._getOne(id));
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Get()
        {
            return Result.Success(await manager._getAll());
        }

        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result> Post(T model)
        {
            return Result.Success(await manager._add(model));
        }

        /// <summary>
        /// 添加多行
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<Result> Patch(List<T> models)
        {
            return Result.Success(await manager._add(models));
        }

        /// <summary>
        /// 修改一行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result> Put(T model)
        {
            return Result.Success(await manager._edit(model));
        }
    }
}