using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using fls.IDAL;
using fls.Models;

namespace fls.DAL
{
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        protected flsDbContext nContext = ContextFactory.GetCurrentContext();
        public T Add(T entity)
        {
            nContext.Entry<T>(entity).State = EntityState.Added;
            nContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return nContext.Set<T>().Count(where);
        }

        public bool Delete(T t)
        {
            nContext.Set<T>().Attach(t);
            nContext.Entry<T>(t).State = EntityState.Deleted;
            return nContext.SaveChanges() > 0;
        }

        public bool Exits(Expression<Func<T, bool>> where)
        {
            return nContext.Set<T>().Any(where);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(where);
            return _entity;
        }

        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> where, bool isAsc, Expression<Func<T, S>> orderLambda)
        {
            var _list = nContext.Set<T>().Where<T>(where);
            if (isAsc) _list = _list.OrderBy<T, S>(orderLambda);
            else _list = _list.OrderByDescending<T, S>(orderLambda);
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, bool isAsc, Expression<Func<T, S>> orderLamdba)
        {
            var _list = nContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = _list.Count();
            if (isAsc) _list = _list.OrderBy<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            else _list = _list.OrderByDescending<T, S>(orderLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        public bool Update(T t)
        {
            nContext.Set<T>().Attach(t);
            nContext.Entry<T>(t).State = EntityState.Modified;
            return nContext.SaveChanges() > 0;
        }
    }
}
