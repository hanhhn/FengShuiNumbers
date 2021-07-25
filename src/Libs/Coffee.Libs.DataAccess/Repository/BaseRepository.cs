using Microsoft.EntityFrameworkCore;
using Coffee.Libs.DataAccess.EntityRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Coffee.Libs.DataAccess.Repository
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : class, IEntityRoot
	{
		public readonly Microsoft.EntityFrameworkCore.DbContext DbContext;

		public BaseRepository(Microsoft.EntityFrameworkCore.DbContext context)
		{
			DbContext = context;
		}

		protected DbSet<TEntity> DbSet
		{
			get
			{
				DbSet<TEntity> entity = DbContext.Set<TEntity>();
				if (entity == null)
				{
					throw new NullReferenceException("Entity can not be set!");
				}

				return entity;
			}
		}

		public virtual IQueryable<TEntity> GetQuery()
		{
			return DbSet;
		}

		public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
		{
			return DbSet.Where(filter);
		}

		public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
		{
			return orderBy(DbSet.Where(filter));
		}

		public virtual TEntity Get(params object[] keyValues)
		{
			return DbSet.Find(keyValues);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			throw new NotImplementedException();
			//return DbSet.AsEnumerable();
		}

		public virtual TEntity Add(TEntity entity)
		{
			return DbSet.Add(entity).Entity;
		}

		public virtual TEntity Update(TEntity entity)
		{
			return DbSet.Update(entity).Entity;
		}

		public virtual void Remove(TEntity entity)
		{
			DbSet.Remove(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			IDeleteEntity common = entity as IDeleteEntity;
			if (common != null)
			{
				common.Delete();
				DbSet.Update(entity);
			}
		}

		public virtual void UnDelete(TEntity entity)
		{
			IDeleteEntity common = entity as IDeleteEntity;
			if (common != null)
			{
				common.UnDelete();
				DbSet.Update(entity);
			}
		}
	}
}
