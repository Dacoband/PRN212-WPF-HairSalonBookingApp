using HairSalonBookingApp.DAO.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace HairSalonBookingApp.DAO
{
    public class BaseDAO<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public BaseDAO(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public bool Add(T entity)
        {
            bool result = false;
            try
            {
                if (entity != null)
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                if (entities != null)
                {
                    _dbSet.AddRange(entities);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool Update(T entity)
        {
            bool result = false;
            try
            {
                if (entity != null)
                {
                    _dbSet.Update(entity);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool UpdateRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                if (entities != null)
                {
                    _dbSet.UpdateRange(entities);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool Delete(T entity)
        {
            bool result = false;
            try
            {
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool DeleteRange(IEnumerable<T> entities)
        {
            bool result = false;
            try
            {
                if (entities != null)
                {
                    _dbSet.RemoveRange(entities);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public int Count(Expression<Func<T, bool>>? filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Count(filter);
            }
            return _dbSet.Count();
        }
    }
}
