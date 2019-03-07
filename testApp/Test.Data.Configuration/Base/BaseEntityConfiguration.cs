using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Entity;

namespace Test.Data.Configuration.Base
{

	[Export(typeof(IEntityConfiguration))]
	public class BaseEntityConfiguration : BaseConfiguration<BaseEntity>
	{
		public BaseEntityConfiguration()
		{

			HasKey(p => p.rec_id);

			Property(p => p.rec_id)
				.IsRequired()
				.HasColumnName("rec_id")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


			Map<Blog>(m =>
			{
				m.ToTable("Blog");
				m.MapInheritedProperties();
			});
			Map<Post>(m =>
			{
				m.ToTable("Post");
				m.MapInheritedProperties();
			});
		}
	}
}
