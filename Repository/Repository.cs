using Microsoft.EntityFrameworkCore;
using Movizi_Portal.Data;
using Movizi_Portal.Repository.IRepository;
using System.Linq.Expressions;

namespace Movizi_Portal.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			dbSet.AddRange(entities);
		}

		public T Get(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query;
			query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query;
			query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
