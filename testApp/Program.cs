using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using Autofac;
using Test.Core.Data;
using Test.Core.Service;
using Test.Core.Utality;
using Test.Entity;

namespace testApp
{
	class Program
	{
		static IContainer Container { get; set; }
		static void Main(string[] args)
		{
			InitCacheDb();
			Container = BuildContainer();
			DependencyHelper.Container = Container;
			var context = DependencyHelper.Resolve<DataContext>();
			using (var container = BuildContainer())
			{
				foreach (var item in container.Resolve<BlogService>().Get())
				{
					Console.WriteLine($"{item.rec_id} - {item.Url}");
				}

				
			}
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();

		}
		private static string GetConnectionString(string basePath, out bool useSqlCompact)
		{
			useSqlCompact = false;
			var dbPath = Path.Combine(basePath, "CacheDb.sdf");
			var filePath = Path.Combine(basePath, "Settings.dat");

			var connectionString = "Data Source=|DataDirectory|\\tempdbumerfridaycopy\\tempabcdb.sdf";

				useSqlCompact = true;

			return connectionString;
		}


		public static void InitCacheDb()
		{
			var connectionString = string.Empty;
			var useSQLCompact = false;
			try
			{
				var spFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tempdbumerfridaycopy");
				if (!Directory.Exists(Path.Combine(spFolderPath, "Logs")))
				{
					Directory.CreateDirectory(Path.Combine(spFolderPath, "Logs"));
				}



				// Set connection string
				connectionString = GetConnectionString(spFolderPath, out useSQLCompact);
				CoreUtils.ConnectionString = connectionString;
				CoreUtils.UseSQLCompact = useSQLCompact;

				//string.Format("Data Source={0}", path);
				if (useSQLCompact)
				{
					Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "",
						connectionString);
				}
				else
				{
					Database.DefaultConnectionFactory = new SqlConnectionFactory(connectionString);
				}
					Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void GetSettings(string spFolderPath = "")
		{
			if (String.IsNullOrEmpty(spFolderPath))
			{
				spFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FridayPos");
			}
			var path = Path.Combine(spFolderPath, "Settings.dat");

			if (File.Exists(path))
			{
				//File.Decrypt(path);
				var data = File.ReadAllText(path);

			}

			
		}

		private static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<DataContext>().AsSelf().InstancePerDependency();
			builder.RegisterGeneric(typeof(EntityService<>)).As(typeof(IEntityService<>));
			builder.RegisterType<BlogService>().As<IBlogService>().AsSelf();
			builder.RegisterType<PostService>().As<IPostService>().AsSelf();
			//_container = builder.Build();
			//DependencyHelper.Container = _container;
			//var context = DependencyHelper.Resolve<DataContext>();
			return builder.Build();
		}

	}
}
