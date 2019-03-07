using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Test.Core.Data
{
	public class MigrationConfiguration : DbMigrationsConfiguration<DataContext>
	{
		public MigrationConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}
	}
	public partial class MigrateToLatestVersion : MigrateDatabaseToLatestVersion<DataContext, MigrationConfiguration>
	{ }
}
