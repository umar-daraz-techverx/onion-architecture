using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Data;
using Test.Entity;

namespace Test.Core.Service
{
	public class EntityService<T> : DbService, IEntityService<T> where T : BaseEntity
	{
		protected IDbSet<T> _repository;

		public EntityService(DataContext context)
			: base(context)
		{
			_repository = context.Set<T>();
		}

		public virtual T Create()
		{
			T entity = _repository.Create();

			Initialize(entity);
			return entity;
		}

		public virtual DataContext Context
		{
			get { return _context; }
		}

		public virtual IDbSet<T> Table
		{
			get { return _repository; }
		}

		public virtual void Save(T entity)
		{
			using (var context = new DataContext())
			{
				try
				{
					ValidateForSave(entity);
					context.Set<T>().AddOrUpdate(i => i.rec_id, entity);
					context.SaveChanges();
				}
				catch (DbEntityValidationException ex)
				{
					foreach (DbValidationError errors in ex.EntityValidationErrors.First().ValidationErrors)
					{
						Console.Out.WriteLine(errors.ErrorMessage);
					}
				}
				catch (Exception e)
				{
					Console.Out.WriteLine(e.Message);
					throw e;
				}
			}
		}

		public virtual void Delete(T entity)
		{
			using (var context = new DataContext())
			{
				context.Set<T>().Remove(entity);
				context.SaveChanges();
			}
			//_repository.Remove(entity);
			//_context.SaveChanges();
		}

		public virtual void Delete(Guid id)
		{
			using (var context = new DataContext())
			{
				var entity = context.Set<T>().FirstOrDefault(c => c.rec_id == id);
				context.Set<T>().Remove(entity);
				context.SaveChanges();
			}

			Delete(_repository.SingleOrDefault(c => c.rec_id == id));
		}

		public virtual T Get(Guid id)
		{
			using (var context = new DataContext())
			{
				T entity;


				entity = context.Set<T>().SingleOrDefault(c => c.rec_id == id);

				Initialize(entity);

				return entity;
			}

		}

		public virtual ICollection<T> List()
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().ToList();
			}
			//return _repository.ToList();

		}

		public virtual ICollection<T> List(Expression<Func<T, bool>> filter)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Where(filter).ToList();
			}

			//return _repository.Where(filter).ToList();

		}


		protected virtual void Initialize(T entity)
		{

		}

		public virtual void ValidateForSave(T entity)
		{
		}


		public ICollection<T> Filter(Expression<Func<T, bool>> predicate)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Where(predicate).ToList();
			}
			//return _repository.Where(predicate).ToList();
		}


		public T FirstOrDefault()
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().FirstOrDefault();
			}

		}


		public T FirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().FirstOrDefault(predicate);
			}

			//return _repository.FirstOrDefault(predicate);
		}

		public ICollection<T> Where(Expression<Func<T, bool>> predicate)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Where(predicate).ToList();
			}
			//return _repository.Where(predicate);
		}


		public void SaveChanges()
		{
			_context.SaveChanges();
		}


		public int Count()
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Count();
			}
			//return _repository.Count();
		}

		public int Count(Expression<Func<T, bool>> predicate)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Count(predicate);
			}
			//return _repository.Count(predicate);
		}

		public bool Any()
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Any();
			}
			//return _repository.Any();
		}

		public bool Any(Expression<Func<T, bool>> predicate)
		{
			using (var context = new DataContext())
			{
				return context.Set<T>().Any(predicate);
			}
		}



		public int ExecuteNonQuery(string sql, params object[] param)
		{
			return Context.Database.ExecuteSqlCommand(sql, param);
		}
	}
}
