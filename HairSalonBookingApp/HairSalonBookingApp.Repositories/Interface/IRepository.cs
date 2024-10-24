using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool UpdateRange(IEnumerable<T> entities);
        bool Delete(T entity);
        bool DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Count the number of entities in the database with optional filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>>? filter);

        /// <summary>
        /// Get entities from database with filter and include properties
        /// includeProperties is a string that contains the properties that you want to include such as "Property1,Property2"
        /// includeProperties string is separated by comma without space
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        /// <summary>
        /// Get a specific from database with filter and include properties
        /// includeProperties is a string that contains the properties that you want to include such as "Property1,Property2"
        /// includeProperties string is separated by comma without space
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
    }
}
