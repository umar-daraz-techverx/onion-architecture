using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Data;
using Test.Entity;

namespace Test.Core.Service
{
	public interface IEntityService<T> where T : BaseEntity
	{
		T Create();

		IDbSet<T> Table { get; }

		void Save(T entity);

		void Delete(T entity);

		void Delete(Guid id);

		T Get(Guid id);

		DataContext Context { get; }

		ICollection<T> List();

		ICollection<T> List(Expression<Func<T, bool>> predicate);

		ICollection<T> Filter(Expression<Func<T, bool>> predicate);

		T FirstOrDefault();

		T FirstOrDefault(Expression<Func<T, bool>> predicate);

		ICollection<T> Where(Expression<Func<T, bool>> predicate);

		void SaveChanges();

		int Count();
		int Count(Expression<Func<T, bool>> predicate);

		bool Any();
		bool Any(Expression<Func<T, bool>> predicate);

		int ExecuteNonQuery(string sql, params object[] param);
	}
}
