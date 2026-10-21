using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
