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
        public bool Create(T entity)
        {
            return this.RepositoryContext.Set<T>().Add(entity).ReloadAsync().IsCompletedSuccessfully;
        }
        public bool Update(T entity)
        {
            return this.RepositoryContext.Set<T>().Update(entity).ReloadAsync().IsCompletedSuccessfully;
        }
        public bool Delete(T entity)
        {
            return this.RepositoryContext.Set<T>().Remove(entity).ReloadAsync().IsCompletedSuccessfully;
        }
    }

}
