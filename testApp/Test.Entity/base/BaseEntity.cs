using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entity
{
	public class BaseEntity
	{
		protected BaseEntity()
		{
			rec_id = Guid.NewGuid();
			created_at = DateTime.Now;
		}
		public Guid rec_id { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }

		public bool IsDeleted { get; set; }
	}
}
