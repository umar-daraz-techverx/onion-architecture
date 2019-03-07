using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core.Data
{
	public class CacheDropCreateDbStrategy : DropCreateDatabaseIfModelChanges<DataContext>
	{
		protected override void Seed(DataContext dbContext)
		{

		}
	}
}
