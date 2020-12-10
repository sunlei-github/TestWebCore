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
        private readonly DbContext _dbContext;

        public RepositoryServices(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> InsertEntity(BaseEntity entity)
        {
            await _dbContext.AddAsync<BaseEntity>(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEntity(BaseEntity entity)
        {
            _dbContext.Update<BaseEntity>(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEntity(BaseEntity entity)
        {
            _dbContext.Remove<BaseEntity>(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<BaseEntity> FindSingleEntity(int key)
        {
            return await _dbContext.FindAsync<BaseEntity>(key);
        }

        public async Task<List<BaseEntity>> FindAllEntity()
        {
            return await _dbContext.Set<BaseEntity>().ToListAsync();
        }

        public async Task<IEnumerable<BaseEntity>> QueryEntity(Expression<Func<BaseEntity, bool>> expression)
        {
            return await Task.Run(() =>
             {
                 List<BaseEntity> entities = new List<BaseEntity>();
                 var entityEnumerators = _dbContext.Set<BaseEntity>().AsQueryable().GetEnumerator();
                 while (entityEnumerators.MoveNext())
                 {
                     entities.Add(entityEnumerators.Current);
                 }

                 return entities.Where(expression.Compile());
             });
        }

        public async Task BeginTransaction(Action transactionAction)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
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
