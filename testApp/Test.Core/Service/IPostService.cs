using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entity;

namespace Test.Core.Service
{
	public interface IPostService
	{
		List<Post> Get();
	}
}
