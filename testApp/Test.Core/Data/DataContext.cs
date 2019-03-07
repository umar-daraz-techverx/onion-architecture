using System;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System.ComponentModel.Composition;
using Test.Data.Configuration.Base;
namespace Test.Core.Data
{
	public class DataContext : DbContext, IDbContext
	{
		public DataContext()
			: base("FridayPos")
		{

			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.LazyLoadingEnabled = true;

		}

		public DataContext(String connectionName)
			: base(connectionName)
		{
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.LazyLoadingEnabled = true;

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			ContextConfiguration contextConfiguration;
			AssemblyCatalog catalog;
			CompositionContainer container;

			contextConfiguration = new ContextConfiguration();
			//data configuration
			catalog = new AssemblyCatalog(Assembly.GetAssembly(typeof(IEntityConfiguration)));
			container = new CompositionContainer(catalog);
			container.ComposeParts(contextConfiguration);


			foreach (var configuration in contextConfiguration.Configurations)
			{
				configuration.AddConfiguration(modelBuilder.Configurations);
			}

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			base.OnModelCreating(modelBuilder);



		}



		public string CreateDatabaseScript()
		{
			return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
		}
	}
}