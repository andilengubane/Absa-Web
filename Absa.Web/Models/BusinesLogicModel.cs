using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Absa.Web.Models
{
	public class BusinesLogicModel
	{
	}

	public class DashBord
	{
		public IEnumerable<SelectListItem> BusinessUnitList { get; set; }
		public string BusinessUnit { get; set; }
	}

	public class ReportModel
	{
		public int ID { get; set; }
		public string BusinessUnit { get; set; }
	}

	public class UserModel
	{
		public IEnumerable<SelectListItem> BusinestUnitList { get; set; }
		public IEnumerable<SelectListItem> RolesPermissionList { get; set; }
		public int ID { get; set; }
		[Required(ErrorMessage = "First Name is a required")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last Name is a required")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Email Address is a required")]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email Address")]
		[Display(Name = "Email")]
		public string EmailAddress { get; set; }
		[Required(ErrorMessage = "Username is a required")]
		[Display(Name = "Username")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Password is a required")]
		[Display(Name = "Password")]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,15}", ErrorMessage = "Password should contain Upper And Lower Case , Numbers and Special characters.")]
		public string Password { get; set; }
		[RegularExpression(@"(?<!\d)\d{10}(?!\d)", ErrorMessage = "Please enter a valid phone number")]
		[Display(Name = "Cellphone Number")]
		public string ContactNumber { get; set; }
		public bool IsActive { get; set; }
		public string BusinessUnit { get; set; }
		public string RolesPermission { get; set; }
	}
	public class ResilienceTrackModel
	{
		public int ResilienceTrackID { get; set; }
		public string ApplicationID { get; set; }
		public string ApplicationName { get; set; }
		public string NameOnSnow { get; set; }
		public string HeadOfTechnology { get; set; }
		public string ApplicatioOwner { get; set; }
		public string ServiceManager { get; set; }
		public long Tiering { get; set; }
		public int BusinessUnitId { get; set; }
		public string BusinessUnit { get; set; }
		public string StrategicFit { get; set; }
		public string DisasterRecovery { get; set; }
		public string BackUpData { get; set; }
		public string BackUpConfiguration { get; set; }
		public string HighAvailability { get; set; }
		public string SPOF { get; set; }
		public string OperationalMonitoring { get; set; }
		public string SecurityMonitoring { get; set; }
		public string InternalOLA { get; set; }
		public string ExternalSLA { get; set; }
		public string ArchitetureDocumentation { get; set; }
		public string OparationsDocumentation { get; set; }
		public string HighestDataClassification { get; set; }
		public string DataRetentionRequirement { get; set; }
		public string IntegratedToAD { get; set; }
		public string JMLProcess { get; set; }
		public string RecertificationProcess { get; set; }
		public string PrivilegedAccessManagement { get; set; }
		public string OSPatchingLevel { get; set; }
		public string ApplicationPatchingLevel { get; set; }
		public string MiddlewarePatchingLevel { get; set; }
		public string SupportedApplication { get; set; }
		public string SupportedOperationSystem { get; set; }
		public string SupportedJava { get; set; }
		public string SupportedMiddleware { get; set; }
		public string SupportedDatabase { get; set; }
		public string OpenVulnerabilities { get; set; }
	}

}