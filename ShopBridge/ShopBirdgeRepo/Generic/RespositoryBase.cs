using Microsoft.EntityFrameworkCore;
using ShopBridgeData.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeRepo
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ShopBridgeContext RepositoryContext { get; set; }
        public RepositoryBase(ShopBridgeContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public async Task<int> Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            return await this.RepositoryContext.SaveChangesAsync();
        }
        public async Task<int> Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            return await this.RepositoryContext.SaveChangesAsync();
        }
        public async Task<int> Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            return await this.RepositoryContext.SaveChangesAsync();
        }
    }

}
