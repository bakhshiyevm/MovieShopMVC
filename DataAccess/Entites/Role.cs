using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
	public class Role : BaseEntity
	{
		[Required]
		public string Name { get; set; }

		public IEnumerable<User> Users = new List<User>();
	}
}
