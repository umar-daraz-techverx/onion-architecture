using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Data;

namespace Test.Core.Service
{
	public class DbService
	{
		protected DataContext _context;
		protected DbService(DataContext context)
		{
			_context = context;
		}
	}
}
