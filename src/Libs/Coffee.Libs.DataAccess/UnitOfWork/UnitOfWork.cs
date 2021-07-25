using Microsoft.EntityFrameworkCore;
using Coffee.Libs.Core.Exeptions;
using Coffee.Libs.DataAccess.EntityRoot;
using Coffee.Libs.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coffee.Libs.DataAccess.UnitOfWork
{
	public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
		 where TContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private readonly Microsoft.EntityFrameworkCore.DbContext _context;

		public UnitOfWork(TContext context)
		{
			_context = context;
		}

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			DetectChanges();

			try
			{
				return await _context.SaveChangesAsync(cancellationToken);
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InformationException("Unable to update or delete. The record modified by another user. Try again!");
			}
		}

		public int SaveChanges()
		{

			DetectChanges();

			try
			{
				return _context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new InformationException("Unable to update or delete. The record modified by another user. Try again!");
			}
		}

		private void DetectChanges()
		{
			_context.ChangeTracker.DetectChanges();
			if (_context.ChangeTracker.HasChanges())
			{
				foreach (var dbEntity in _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
				{
					IChangeableEntity entity = dbEntity.Entity as IChangeableEntity;
					if (entity == null)
						continue;

					var logged ="sys";
					if (dbEntity.State == EntityState.Added)
					{
						entity.Default(logged);
						continue;
					}

					if (dbEntity.State == EntityState.Modified)
					{
						entity.Default(logged, false);
					}
				}
			}
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}