using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Data;
using Test.Entity;

namespace Test.Core.Service
{
	public class PostService : IPostService
	{
		public List<Post> Get()
		{
			using (var context = new DataContext())
			{
				return context.Set<Post>().ToList();
			}
		}
	}
}
