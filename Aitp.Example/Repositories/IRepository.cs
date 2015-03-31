using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aitp.Example
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Selects data from the data store that matches all of the provided criteria
        /// </summary>
        /// <param name="criteria">Restrictions to qualify on</param>
        /// <returns>a collection of matching <typeparamref name="TEntity"/></returns>
        ICollection<TEntity> Select(ICriteria<TEntity> criteria);

        /// <summary>
        /// Attempts to insert an entity into the data store
        /// </summary>
        void Insert(TEntity entity);

        /// <summary>
        /// Attempts to update an entity into the data store
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Attempts to remove an entity into the data store
        /// </summary>
        void Remove(TEntity entity);
    }
}
