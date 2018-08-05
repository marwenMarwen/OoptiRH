using Microsoft.EntityFrameworkCore;
using OoptiRH.DBAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OoptiRH.DBAcess.Implementations
{
    public class DBRepository<TEntity> : IDBRepository<TEntity> where TEntity : class
    {
        internal OoptiRHContext _ooptiRHcontext;
        internal DbSet<TEntity> dbSet;

        public DBRepository(OoptiRHContext appcontext)
        {
            this._ooptiRHcontext = appcontext;
            this.dbSet = this._ooptiRHcontext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetByID(object id)
        {
            return dbSet.Find((System.Int32)id);
        }

        public TEntity GetEntityBy(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
            this._ooptiRHcontext.SaveChanges();

        }

        public void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this._ooptiRHcontext.Entry(entityToUpdate).State = EntityState.Modified;
            this._ooptiRHcontext.SaveChanges();
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);

            if (this._ooptiRHcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);

            this._ooptiRHcontext.SaveChanges();
        }
    }
}
