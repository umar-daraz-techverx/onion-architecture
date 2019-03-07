using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Test.Data.Configuration.Base;

namespace Test.Core.Data
{
	public class ContextConfiguration
	{
		[ImportMany(typeof(IEntityConfiguration))]
		public IEnumerable<IEntityConfiguration> Configurations { get; set; }
	}
}
