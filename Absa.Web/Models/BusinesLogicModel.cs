using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Absa.Web.Models
{
	public class DeclineModel
	{
		public IEnumerable<SelectListItem> ApplicationDeclined { get; set; }
		public string BusinessUnitName { get; set; }
		public string BusinessUnit { get; set; }
		public string ApplicationId { get; set; }
		public string FullName { get; set; }
		public string Manager { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
	}
	public class DashBordModel
	{
		public IEnumerable<SelectListItem> BusinessUnitList { get; set; }
		public int NumberOfApps { get; set; }
		public string BusinessUnit { get; set; }
		public int StrategicFitYes { get; set; }
		public int StrategicFitNo { get; set; }
		public int StrategicFitWarning { get; set; }
		public int StrategicFitOverRall { get; set; }
		public int DisasterRecoveryYes { get; set; }
		public int DisasterRecoveryNo { get; set; }
		public int DisasterRecoveryWarning { get; set; }
		public int DisasterRecoverOverRall { get; set; }
		public int BackUpDataYes { get; set; }
		public int BackUpDataNo { get; set; }
		public int BackUpDataWarning { get; set; }
		public int BackUpDataOverRall { get; set; }
		public int BackUpConfigurationYes { get; set; }
		public int BackUpConfigurationNo { get; set; }
		public int BackUpConfigurationWarning { get; set; }
		public int BackUpConfigurationOverRall { get; set; }
		public int HighAvailabilityYes { get; set; }
		public int HighAvailabilityNo { get; set; }
		public int HighAvailabilityWarning { get; set; }
		public int HighAvailabilityOverRall {get;set;}
		public int OperationalMonitoringYes { get; set; }
		public int OperationalMonitoringNo { get; set; }
		public int OperationalMonitoringWarning { get; set; }
		public int OperationalMonitoringOverRall { get;set;}
		public int SecurityMonitoringYes { get; set; }
		public int SecurityMonitoringNo { get; set; }
		public int SecurityMonitoringWarning { get; set; }
		public int SecurityMonitoringOverRall { get; set; }
		public int SPOFYes { get; set; }
		public int SPOFNo { get; set; }
		public int SPOFWarning { get; set; }
		public int SPOFOverRall { get; set; }
		public int InternalOLAYes { get; set; }
		public int InternalOLANo { get; set; }
		public int InternalOLAWarning { get; set; }
		public int InternalOLAOverRall { get; set; }
		public int ExternalSLAYes { get; set; }
		public int ExternalSLANo { get; set; }
		public int ExternalSLAWarning { get; set; }
		public int ExternalSLAOverRall { get; set; }
		public int ArchitectureDocumentationYes { get; set; }
		public int ArchitectureDocumentationNo { get; set; }
		public int ArchitectureDocumentationWarning { get; set; }
		public int ArchitectureDocumentationOverRall { get; set; }
		public int OparationsDocumentationYes { get; set; }
		public int OparationsDocumentationNo { get; set; }
		public int OparationsDocumentationWarning { get; set; }
		public int OparationsDocumentationOverRall { get; set; }
		public int HighestDataClassificationYes { get; set; }
		public int HighestDataClassificationNo { get; set; }
		public int HighestDataClassificationWarning { get; set; }
		public int HighestDataClassificationOverRall { get; set; }
		public int DataRetentionRequirementYes { get; set; }
		public int DataRetentionRequirementNo { get; set; }
		public int DataRetentionRequirementWarning { get; set; }
		public int DataRetentionRequirementOverRall { get; set; }
		public int IntegratedToADYes { get; set; }
		public int IntegratedToADNo { get; set; }
		public int IntegratedToADWarning { get; set; }
		public int IntegratedToADOverRall { get; set; }
		public int JMLProcessYes { get; set; }
		public int JMLProcessNo { get; set; }
		public int JMLProcessWarning { get; set; }
		public int JMLProcessOverRall { get; set; }
		public int PrivilegedAccessManagementYes { get; set; }
		public int PrivilegedAccessManagementNo { get; set; }
		public int PrivilegedAccessManagementWarning { get; set; }
		public int PrivilegedAccessManagementOverRall { get; set; }
		public int RecertificationProcessYes { get; set; }
		public int RecertificationProcessNo { get; set; }
		public int RecertificationProcessWarning { get; set; }
		public int RecertificationProcessOverRall { get; set; }
		public int OSPatchingLevelYes { get; set; }
		public int OSPatchingLevelNo { get; set; }
		public int OSPatchingLevelWarning { get; set; }
		public int OSPatchingLevelOverRall { get; set; }
		public int ApplicationPatchingLevelYes { get; set; }
		public int ApplicationPatchingLevelNo { get; set; }
		public int ApplicationPatchingLevelWarning { get; set; }
		public int ApplicationPatchingLevelOverRall { get; set; }
		public int MiddlewarePatchingLevelYes { get; set; }
		public int MiddlewarePatchingLevelNo { get; set; }
		public int MiddlewarePatchingLevelWarning { get; set; }
		public int MiddlewarePatchingLevelOverRall { get; set; }
		public int SupportedApplicationYes { get; set; }
		public int SupportedApplicationNo { get; set; }
		public int SupportedApplicationWarning { get; set; }
		public int SupportedApplicationOverRall { get; set; }
		public int SupportedOperationSystemYes { get; set; }
		public int SupportedOperationSystemNo { get; set; }
		public int SupportedOperationSystemWarning { get; set; }
		public int SupportedOperationSystemOverRall { get; set; }
		public int SupportedJavaYes { get; set; }
		public int SupportedJavaNo { get; set; }
		public int SupportedJavaWarning { get; set; }
		public int SupportedJavaOverRall { get; set; }
		public int SupportedMiddlewareYes { get; set; }
		public int SupportedMiddlewareNo { get; set; }
		public int SupportedMiddlewareWarning { get; set; }
		public int SupportedMiddlewareOverRall { get; set; }
		public int SupportedDatabaseYes { get; set; }
		public int SupportedDatabaseNo { get; set; }
		public int SupportedDatabaseWarning { get; set; }
		public int SupportedDatabaseOverRall { get; set; }
		public int OpenVulnerabilitiesYes { get; set; }
		public int OpenVulnerabilitiesNo { get; set; }
		public int OpenVulnerabilitiesWarning { get; set; }
		public int OpenVulnerabilitiesOverRall { get; set; }
	}
	public class ReportModel
	{
		public int ID { get; set; }
		public string BusinessUnit { get; set; }
		public int BusinessUnitId { get; set; }
		public IEnumerable<SelectListItem> BusinessUnitList { get; set; }
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
		public IEnumerable<SelectListItem> StatusList { get; set; }
		public int ResilienceTrackID { get; set; }
		public int UserID { get; set; }
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
		public string Description { get; set; }
	}
}