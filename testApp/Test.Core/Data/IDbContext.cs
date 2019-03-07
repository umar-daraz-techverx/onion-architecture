using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Test.Core.Data
{
	public interface IDbContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		int SaveChanges();

		DbContextConfiguration Configuration { get; }

		Database Database { get; }
	}
}
