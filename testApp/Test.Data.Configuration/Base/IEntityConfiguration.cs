using System.Data.Entity.ModelConfiguration.Configuration;

namespace Test.Data.Configuration.Base
{
	public interface IEntityConfiguration
	{
		void AddConfiguration(ConfigurationRegistrar registrar);
	}
}