using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WebApi.Repository.Repository
{
    public interface IRepositoryServices<Entity>
        where Entity : class, IEntity
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> InsertEntity(Entity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateEntity(Entity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteEntity(Entity entity);

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Entity> FindSingleEntity(int key);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<Entity>> FindAllEntity();

        /// <summary>
        ///   查询实体
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Entity>> QueryEntity(Expression<Func<Entity, bool>> expression);

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="transactionAction"></param>
        /// <returns></returns>
        Task BeginTransaction(Action transactionAction);


    }
}
