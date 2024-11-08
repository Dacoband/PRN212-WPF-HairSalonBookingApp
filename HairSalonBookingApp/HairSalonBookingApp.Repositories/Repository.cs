﻿using HairSalonBookingApp.BusinessObjects.Entities;
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
        public bool Add(T entity) => _dao.Add(entity);

        public bool AddRange(IEnumerable<T> entities) => _dao.AddRange(entities);

        public int Count(Expression<Func<T, bool>>? filter) => _dao.Count(filter);

        public bool Delete(T entity) => _dao.Delete(entity);

        public bool DeleteRange(IEnumerable<T> entities) => _dao.DeleteRange(entities);

        public T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null) => _dao.Get(filter, includeProperties);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null) => _dao.GetAll(filter, includeProperties);

        public bool Update(T entity) => _dao.Update(entity);

        public bool UpdateRange(IEnumerable<T> entities) => _dao.UpdateRange(entities);

        public async Task<bool> AddAsync(T entity) => await _dao.AddAsync(entity);

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities) => await _dao.AddRangeAsync(entities);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter) => await _dao.CountAsync(filter);

        public async Task<bool> DeleteAsync(T entity) => await _dao.DeleteAsync(entity);

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities) => await _dao.DeleteRangeAsync(entities);

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
            => await _dao.GetAsync(filter, includeProperties);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
            => await _dao.GetAllAsync(filter, includeProperties);

        public async Task<bool> UpdateAsync(T entity) => await _dao.UpdateAsync(entity);

        public async Task<bool> UpdateRangeAsync(IEnumerable<T> entities) => await _dao.UpdateRangeAsync(entities);
    }
}
