using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.BaseEntity;
using System.Threading.Tasks;
using WebApi.EntityFramework;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository.Repository
{
    public class RepositoryServices<BaseEntity> : IRepositoryServices<BaseEntity>
        where BaseEntity : class, IEntity
    {
        //private readonly WebApiDbContext _webApiDbContext;
        private readonly DbContext _webApiDbContext;

        public RepositoryServices(WebApiDbContext webApiDbContext)
        {
            _webApiDbContext = webApiDbContext;
        }

        public async Task<int> InsertEntity(BaseEntity entity)
        {
            await _webApiDbContext.AddAsync<BaseEntity>(entity);

            return await _webApiDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEntity(BaseEntity entity)
        {
            _webApiDbContext.Update<BaseEntity>(entity);

            return await _webApiDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEntity(BaseEntity entity)
        {
            _webApiDbContext.Remove<BaseEntity>(entity);

            return await _webApiDbContext.SaveChangesAsync();
        }

        public async Task<BaseEntity> FindSingleEntity(int key)
        {
            return await _webApiDbContext.FindAsync<BaseEntity>(key);
        }

        public async Task<IEnumerable<BaseEntity>> QueryEntity(Expression<Func<BaseEntity, bool>> expression)
        {
            return await Task.Run(() =>
             {
                 List<BaseEntity> entities = new List<BaseEntity>();
                 var entityEnumerators = _webApiDbContext.Set<BaseEntity>().AsQueryable().GetEnumerator();
                 while (entityEnumerators.MoveNext())
                 {
                     entities.Add(entityEnumerators.Current);
                 }

                 return entities.Where(expression.Compile());
             });
        }

        public async Task BeginTransaction(Action transactionAction)
        {
            using (var transaction = await _webApiDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    transactionAction.Invoke();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }

                await transaction.CommitAsync();
            }
        }

    }
}
