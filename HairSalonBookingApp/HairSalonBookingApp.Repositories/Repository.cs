using HairSalonBookingApp.BusinessObjects.Entities;
using HairSalonBookingApp.DAO;
using HairSalonBookingApp.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BaseDAO<T> _dao;
        public Repository(BaseDAO<T> dao) { _dao = dao; }

        public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            return await _dao.AddAsync(entity, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _dao.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            return await _dao.CountAsync(filter, cancellationToken);
        }

        public bool Delete(params T[] entities)
        {
            return _dao.Delete(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, CancellationToken cancellationToken = default)
        {
            return await _dao.GetAllAsync(filter, includeProperties, cancellationToken);
        }

        public async Task<T?> GetAsync(Guid id, string? includeProperties = null, CancellationToken cancellationToken = default)
        {
            return await _dao.GetAsync(id, includeProperties, cancellationToken);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _dao.GetAsync(filter, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetWithPaginationAsync(int pageNum = 0, int pageSize = 0, Expression<Func<T, bool>>? filter = null, string? includeProperties = null, CancellationToken cancellationToken = default)
        {
            return await _dao.GetWithPaginationAsync(pageNum, pageSize, filter, includeProperties, cancellationToken);
        }

        public bool Update(T entity)
        {
            return _dao.Update(entity);
        }

        public bool UpdateRange(IEnumerable<T> entities)
        {
            return _dao.UpdateRange(entities);
        }
    }
}
