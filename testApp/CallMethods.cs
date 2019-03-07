using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Core.Service;
using Test.Entity;

namespace testApp
{
	public class CallMethods
	{
		
		private readonly IBlogService _blogService;
		public CallMethods()
		{
			
		}
		public CallMethods(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public void show()
		{
			foreach (var item in _blogService.Get())
			{
				Console.WriteLine($"{item.rec_id}-{item.Url}");
			}
		}

		public bool add(Blog blog)
		{
			return _blogService.add(blog);
		}
	}
}
