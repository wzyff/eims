﻿using Eims.IBLL;
using Eims.WebApi.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Eims.WebApi.Controllers
{
    /// <summary>
    /// 通用Controller
    /// [Attribute]是给类的，可以继承，所以继承basecontroll都会管理员过滤
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    [MainAuth(RoleValidation = true)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController<T, M> : ApiController where M : IBaseManager<T>
    {
        [Dependency]
        public M manager { get; set; }

        public async Task<int> Delete(int id)
        {
            return await manager._del(id);
        }

        public async Task<List<T>> Get(int pageIndex, string key = null)
        {
            return await manager._getPage(10, pageIndex, key);
        }

        public async Task<T> Get(int id)
        {
            return await manager._getOne(id);
        }

        public async Task<List<T>> Get()
        {
            return await manager._getAll();
        }

        public async Task<int> Post([FromBody] T model)
        {
            return await manager._add(model);
        }

        public async Task<int> Put([FromBody] T model)
        {
            return await manager._edit(model);
        }
    }
}