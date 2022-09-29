using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }
		[Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public int RoleId { get; set; }
		public Role Role { get; set; }


	}
}
