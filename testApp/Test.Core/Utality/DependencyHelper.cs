using Autofac;


namespace Test.Core.Utality
{
	public static class DependencyHelper
	{
		public static IContainer Container { get; set; }

		public static T Resolve<T>()
		{
			return Container.Resolve<T>();
		}
	}
}
