using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entity
{
	public class Blog:BaseEntity
	{
		public string Url { get; set; }
		public List<Post> Posts { get; set; }
	}
}
