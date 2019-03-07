using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Configuration.Base;
using Test.Entity;

namespace Test.Data.Configuration
{
	[Export(typeof(IEntityConfiguration))]
	public class PostConfigurations: BaseConfiguration<Post>
	{
		public PostConfigurations()
		{
			//HasKey(o => o.rec_id);
			//HasOptional(o => o.BlogId).WithMany().HasForeignKey(h => h.ShiftId);
		}
	}
}
