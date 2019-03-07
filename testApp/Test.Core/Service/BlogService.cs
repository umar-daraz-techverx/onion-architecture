using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entity;

namespace Test.Core.Service
{
	public class BlogService : IBlogService
	{
		#region Fields

		private readonly IEntityService<Blog> _blogRepository;
		#endregion

		public BlogService(IEntityService<Blog> blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public bool add(Blog blog)
		{
		 _blogRepository.Save(blog);
			return true;
		}

		public List<Blog> Get()
		{
			return _blogRepository.List(x=>x.IsDeleted==false).ToList();
		}
	}
}
