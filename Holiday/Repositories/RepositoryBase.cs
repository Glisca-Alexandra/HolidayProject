using Holiday.DataBaseContext;
using Holiday.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Holiday.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HolidayContext HolidayContext { get; set; }
        public RepositoryBase(HolidayContext holidayContext)
        {
            this.HolidayContext = holidayContext;
        }

        public IQueryable<T> FindAll()
        { 
            return this.HolidayContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.HolidayContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.HolidayContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.HolidayContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.HolidayContext.Set<T>().Remove(entity);
        }
    }
}
