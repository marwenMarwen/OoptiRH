using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OoptiRH.DBAcess.Interfaces
{
    public interface IDBRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all value from an entity
        /// </summary>
        /// <param name="includeProperties">linked entity to include</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(string includeProperties = "");

        /// <summary>
        /// select data with condition, order then and includ linked entity
        /// </summary>
        /// <param name="filter"> expression to filter data</param>
        /// <param name="orderBy">function to order data</param>
        /// <param name="includeProperties"> linked entities to include</param>
        /// <returns> filtred and ordred data with linked entity </returns>
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");


        /// <summary>
        /// get entity
        /// </summary>
        /// <param name="id">the entity identifier</param>
        /// <returns></returns>
        TEntity GetByID(object id);


        /// <summary>
        /// Get the first or default element based on condition
        /// </summary>
        /// <param name="filter">expression to filter data</param>
        /// <param name="includeProperties">linked entities to include</param>
        /// <returns>the first or default entity</returns>
        TEntity GetEntityBy(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        /// <summary>
        /// insert entity to the database
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);


        /// <summary>
        /// delete entity from database 
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        /// update entity in the database
        /// </summary>
        /// <param name="entityToUpdate">the entity to update</param>
        void Update(TEntity entityToUpdate);

    }

}
