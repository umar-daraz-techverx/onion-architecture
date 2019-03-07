

using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Test.Data.Configuration.Base
{
	public class BaseConfiguration<T> : EntityTypeConfiguration<T>, IEntityConfiguration where T : class
	{
		public void AddConfiguration(ConfigurationRegistrar registrar)
		{
			registrar.Add(this);
		}
	}
}
