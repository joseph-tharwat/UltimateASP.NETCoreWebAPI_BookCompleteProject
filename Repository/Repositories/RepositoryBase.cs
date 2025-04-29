using Contracts.IRepositoy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected RepositoryContext dbContext;
        public RepositoryBase(RepositoryContext contextt)
        {
            dbContext = contextt;
        }
        public void Create(T entity)
        {
            //dbContext.Add<T>(entity);
            dbContext.Set<T>().Add(entity);   
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges? dbContext.Set<T>(): dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges? 
                dbContext.Set<T>().Where(expression):
                dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
