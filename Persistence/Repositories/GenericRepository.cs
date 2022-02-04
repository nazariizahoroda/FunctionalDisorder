using Domain.Repository_interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected ApplicationContext RepositoryContext { get; set; }
        public GenericRepository(ApplicationContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<TEntity> FindAll()
        {
            return RepositoryContext.Set<TEntity>().AsNoTracking();
        }
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return RepositoryContext.Set<TEntity>()
                .Where(expression).AsNoTracking();
        }
        public async Task CreateAsync(TEntity entity)
        {
            await RepositoryContext.Set<TEntity>().AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            RepositoryContext.Set<TEntity>().Remove(entity);
        }
    }
}