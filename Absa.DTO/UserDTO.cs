using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Absa.DTO
{
	public class UserDTO
	{
		[Key]
		public int ID { get; set; }
		[Required(ErrorMessage = "First Name is a required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last Name is a required")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Email Address is a required")]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email Address")]
		public string EmailAddress { get; set; }
		[Required(ErrorMessage = "Username is a required")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Password is a required")]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,15}", ErrorMessage = "Password should contain Upper And Lower Case, Numbers and Special characters.")]
		public string Password { get; set; }
		[RegularExpression(@"(?<!\d)\d{10}(?!\d)", ErrorMessage = "Please enter a valid phone number")]
		public string ContactNumber { get; set; }
		public bool IsActive { get; set; }
		public string BusinessUnit { get; set; }
		public string RolesPermission { get; set; }
		public IEnumerable<SelectListItem> BusinestUnitList { get; set; }
		public IEnumerable<SelectListItem> RolesPermissionList { get; set; }
	}
}
