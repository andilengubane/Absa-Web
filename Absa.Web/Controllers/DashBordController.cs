using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.Web.Models;
using Absa.DateAccess;
using System.Collections.Generic;

namespace Absa.Web.Controllers
{
    public class DashBordController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
	
		public ActionResult StrategicFit()
		{
			return PartialView();
		}

		public ActionResult GetAllApplicationData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var strategicFitAppData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitAppData)
			{
				model.StrategicFitYes = Convert.ToInt32(item.StrategicFitYes);
				model.StrategicFitNo = Convert.ToInt32(item.StrategicFitNo);
				model.StrategicFitWarning = Convert.ToInt32(item.StrategicFitWarning);
				model.StrategicFitOverRall = Convert.ToInt32(item.StrategicFitOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult DisasterRecovery()
		{
			return PartialView();
		}

		public ActionResult GetDisasterRecoveryData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var disasterRecoveryData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in disasterRecoveryData)
			{
				model.DisasterRecoveryYes = Convert.ToInt32(item.DisasterRecoverYes);
				model.DisasterRecoveryNo = Convert.ToInt32(item.DisasterRecoverNo);
				model.DisasterRecoveryWarning = Convert.ToInt32(item.DisasterRecoverWarning);
				model.DisasterRecoverOverRall = Convert.ToInt32(item.DisasterRecoverOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult BackUpData()
		{
			return PartialView();
		}

		public ActionResult GetBackUpData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var backUpData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in backUpData)
			{
				model.BackUpDataYes = Convert.ToInt32(item.BackUpDataYes);
				model.BackUpDataNo = Convert.ToInt32(item.BackUpDataNo);
				model.BackUpDataWarning = Convert.ToInt32(item.BackUpDataWarning);
				model.BackUpDataOverRall = Convert.ToInt32(item.BackUpDataOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult BackUpConfiguration()
		{
			return PartialView();
		}

		public ActionResult GetBackUpConfigurationData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var backUpConfigurationData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in backUpConfigurationData)
			{
				model.BackUpConfigurationYes = Convert.ToInt32(item.BackUpConfigurationYes);
				model.BackUpConfigurationNo = Convert.ToInt32(item.BackUpConfigurationNo);
				model.BackUpConfigurationWarning = Convert.ToInt32(item.BackUpConfigurationWarning);
				model.BackUpConfigurationOverRall = Convert.ToInt32(item.BackUpConfigurationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult HighAvailability()
		{
			return PartialView();
		}

		public ActionResult GetHighAvailabiltyData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.HighAvailabilityYes = Convert.ToInt32(item.HighAvailabilityYes);
				model.HighAvailabilityNo = Convert.ToInt32(item.HighAvailabilityNo);
				model.HighAvailabilityWarning = Convert.ToInt32(item.HighAvailabilityWarning);
				model.HighAvailabilityOverRall = Convert.ToInt32(item.HighAvailabilityOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SinglePointOfFailure()
		{
			return PartialView();
		}

		public ActionResult GetSinglePointOfFailure()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.SPOFYes = Convert.ToInt32(item.SPOFYes);
				model.SPOFNo = Convert.ToInt32(item.SPOFNo);
				model.SPOFWarning = Convert.ToInt32(item.SPOFWarning);
				model.SPOFOverRall = Convert.ToInt32(item.SPOFOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult HighestDataClassification()
		{
			return PartialView();
		}

		public ActionResult GetHighestDataClassification()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.HighestDataClassificationYes = Convert.ToInt32(item.HighestDataClassificationYes);
				model.HighestDataClassificationNo = Convert.ToInt32(item.HighestDataClassificationNo);
				model.HighestDataClassificationWarning = Convert.ToInt32(item.HighestDataClassificationWarning);
				model.HighestDataClassificationOverRall = Convert.ToInt32(item.HighestDataClassificationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult DataRetentionRequirement()
		{
			return PartialView();
		}

		public ActionResult GetDataRetentionRequirement()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.DataRetentionRequirementYes = Convert.ToInt32(item.DataRetentionRequirementYes);
				model.DataRetentionRequirementNo = Convert.ToInt32(item.DataRetentionRequirementNo);
				model.DataRetentionRequirementWarning = Convert.ToInt32(item.DataRetentionRequirementWarning);
				model.DataRetentionRequirementOverRall = Convert.ToInt32(item.DataRetentionRequirementOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
		public ActionResult OperationalMonitoring()
		{
			return PartialView();
		}

		public ActionResult GetOperationalMonitoring()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.OperationalMonitoringYes = Convert.ToInt32(item.OperationalMonitoringYes);
				model.OperationalMonitoringNo = Convert.ToInt32(item.OperationalMonitoringNo);
				model.OperationalMonitoringWarning = Convert.ToInt32(item.OperationalMonitoringWarning);
				model.OperationalMonitoringOverRall = Convert.ToInt32(item.OperationalMonitoringOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SecurityMonitoring()
		{
			return PartialView();
		}

		public ActionResult GetSecurityMonitoring()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.SecurityMonitoringYes = Convert.ToInt32(item.SecurityMonitoringYes);
				model.SecurityMonitoringNo = Convert.ToInt32(item.SecurityMonitoringNo);
				model.SecurityMonitoringWarning = Convert.ToInt32(item.SecurityMonitoringWarning);
				model.SecurityMonitoringOverRall = Convert.ToInt32(item.SecurityMonitoringOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult InternalOLA()
		{
			return PartialView();
		}

		public ActionResult GetInternalOLA()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highAvailabiltyData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highAvailabiltyData)
			{
				model.InternalOLAYes = Convert.ToInt32(item.InternalOLAYes);
				model.InternalOLANo = Convert.ToInt32(item.InternalOLANo);
				model.InternalOLAWarning = Convert.ToInt32(item.InternalOLAWarning);
				model.InternalOLAOverRall = Convert.ToInt32(item.InternalOLAOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
	   }

	    public ActionResult ExternalSLA()
	   {
		  return PartialView();
	   }

	    public ActionResult GetExternalSLA()
	    {
		   var id = this.Session["ID"];
		   int userId = Convert.ToInt32(id);
		   var data = context.Users.FirstOrDefault(u => u.UserID == userId);
		   var model = new DashBordModel();

		   var externalSLA = context.GetAppStatus(data.BusinessUnitId);
		   foreach (var item in externalSLA)
		   {
			  model.ExternalSLAYes = Convert.ToInt32(item.ExternalSLAYes);
			  model.ExternalSLANo = Convert.ToInt32(item.ExternalSLANo);
			  model.ExternalSLAWarning = Convert.ToInt32(item.ExternalSLAWarning);
			  model.ExternalSLAOverRall = Convert.ToInt32(item.ExternalSLAOverRall);
		   }
		    return Json(model, JsonRequestBehavior.AllowGet);
	    }

		public ActionResult ArchictetureDocumentation()
		{
			return PartialView();
		}

		public ActionResult GetArchictetureDocumentation()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var archictetureDocumentation = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in archictetureDocumentation)
			{
				model.ArchitectureDocumentationYes = Convert.ToInt32(item.ArchitetureDocumentationYes);
				model.ArchitectureDocumentationNo = Convert.ToInt32(item.ArchitetureDocumentationNo);
				model.ArchitectureDocumentationWarning = Convert.ToInt32(item.ArchitetureDocumentationWarning);
				model.ArchitectureDocumentationOverRall = Convert.ToInt32(item.ArchitetureDocumentationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult OperationalDocumentation()
		{
			return PartialView();
		}

		public ActionResult GetOperationalDocumentation()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var operationalDocumentation = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in operationalDocumentation)
			{
				model.OparationsDocumentationYes = Convert.ToInt32(item.OparationsDocumentationYes);
				model.OparationsDocumentationNo = Convert.ToInt32(item.OparationsDocumentationNo);
				model.OparationsDocumentationWarning = Convert.ToInt32(item.OparationsDocumentationWarning);
				model.OparationsDocumentationOverRall = Convert.ToInt32(item.OparationsDocumentationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult IntegratedtoAD()
		{
			return PartialView();
		}

		public ActionResult GetIntegratedtoAD()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var integratedtoAD = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in integratedtoAD)
			{
				model.IntegratedToADYes = Convert.ToInt32(item.IntegratedToADYes);
				model.IntegratedToADNo = Convert.ToInt32(item.IntegratedToADNo);
				model.IntegratedToADWarning = Convert.ToInt32(item.IntegratedToADWarning);
				model.IntegratedToADOverRall = Convert.ToInt32(item.IntegratedToADOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult JMLProcess()
		{
			return PartialView();
		}
		public ActionResult GetJMLProcess()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var jmlProcess = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in jmlProcess)
			{
				model.JMLProcessYes = Convert.ToInt32(item.JMLProcessYes);
				model.JMLProcessNo = Convert.ToInt32(item.JMLProcessNo);
				model.JMLProcessWarning = Convert.ToInt32(item.JMLProcessWarning);
				model.JMLProcessOverRall = Convert.ToInt32(item.JMLProcessOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult RecertificationProcess()
		{
			return PartialView();
		}

		public ActionResult GetRecertificationProcess()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var recertificationProcess = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in recertificationProcess)
			{
				model.RecertificationProcessYes = Convert.ToInt32(item.RecertificationProcessYes);
				model.RecertificationProcessNo = Convert.ToInt32(item.RecertificationProcessNo);
				model.RecertificationProcessWarning = Convert.ToInt32(item.RecertificationProcessWarning);
				model.RecertificationProcessOverRall = Convert.ToInt32(item.RecertificationProcessOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult PrivilegedAccessManagement()
		{
			return PartialView();
		}

		public ActionResult GetPrivilegedAccessManagement()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();
			
			var privilegedAccessManagement = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in privilegedAccessManagement)
			{
				model.PrivilegedAccessManagementYes = Convert.ToInt32(item.PrivilegedAccessManagementYes);
				model.PrivilegedAccessManagementNo = Convert.ToInt32(item.PrivilegedAccessManagementNo);
				model.PrivilegedAccessManagementWarning = Convert.ToInt32(item.PrivilegedAccessManagementWarning);
				model.PrivilegedAccessManagementOverRall = Convert.ToInt32(item.PrivilegedAccessManagementOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult OSPatchingLevel()
		{
			return PartialView();
		}

		public ActionResult GetOSPatchingLevel()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var osPatchingLevel = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in osPatchingLevel)
			{
				model.OSPatchingLevelYes = Convert.ToInt32(item.OSPatchingLevelYes);
				model.OSPatchingLevelNo = Convert.ToInt32(item.OSPatchingLevelNo);
				model.OSPatchingLevelWarning = Convert.ToInt32(item.OSPatchingLevelWarning);
				model.OSPatchingLevelOverRall = Convert.ToInt32(item.OSPatchingLevelOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult ApplicationPatchingLevel()
		{
			return PartialView();
		}

		public ActionResult GetApplicationPatchingLevel()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();
			
			var applicationPatchingLevel = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in applicationPatchingLevel)
			{
				model.ApplicationPatchingLevelYes = Convert.ToInt32(item.ApplicationPatchingLevelYes);
				model.ApplicationPatchingLevelNo = Convert.ToInt32(item.ApplicationPatchingLevelNo);
				model.ApplicationPatchingLevelWarning = Convert.ToInt32(item.ApplicationPatchingLevelWarning);
				model.ApplicationPatchingLevelOverRall = Convert.ToInt32(item.ApplicationPatchingLevelOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult MiddlewarePatchingLevel()
		{
			return PartialView();
		}

		public ActionResult GetMiddlewarePatchingLevel()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var middlewarePatchingLevel = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in middlewarePatchingLevel)
			{
				model.MiddlewarePatchingLevelYes = Convert.ToInt32(item.MiddlewarePatchingLevelNo);
				model.MiddlewarePatchingLevelNo = Convert.ToInt32(item.ApplicationPatchingLevelNo);
				model.MiddlewarePatchingLevelWarning = Convert.ToInt32(item.MiddlewarePatchingLevelWarning);
				model.MiddlewarePatchingLevelOverRall = Convert.ToInt32(item.MiddlewarePatchingLevelOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportedApplication()
		{
			return PartialView();
		}

		public ActionResult GetSupportedApplication()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();
			
			var middlewarePatchingLevel = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in middlewarePatchingLevel)
			{
				model.SupportedApplicationYes = Convert.ToInt32(item.SupportedApplicationYes);
				model.SupportedApplicationNo = Convert.ToInt32(item.SupportedApplicationNo);
				model.SupportedApplicationWarning = Convert.ToInt32(item.SupportedApplicationWarning);
				model.SupportedApplicationOverRall = Convert.ToInt32(item.SupportedApplicationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportedOperationSystem()
		{
			return PartialView();
		}

		public ActionResult GetSupportedOperationSystem()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();
			
			var supportedOperationSystem = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportedOperationSystem)
			{
				model.SupportedOperationSystemYes = Convert.ToInt32(item.SupportedOperationSystemYes);
				model.SupportedOperationSystemNo = Convert.ToInt32(item.SupportedOperationSystemNo);
				model.SupportedOperationSystemWarning = Convert.ToInt32(item.SupportedOperationSystemWarning);
				model.SupportedOperationSystemOverRall = Convert.ToInt32(item.SupportedOperationSystemOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportedJava()
		{
			return PartialView();
		}

		public ActionResult GetSupportedJava()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportedJava = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportedJava)
			{
				model.SupportedJavaYes = Convert.ToInt32(item.SupportedJavaYes);
				model.SupportedJavaNo = Convert.ToInt32(item.SupportedJavaNo);
				model.SupportedJavaWarning = Convert.ToInt32(item.SupportedJavaWarning);
				model.SupportedJavaOverRall = Convert.ToInt32(item.SupportedJavaOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportedMiddleware()
		{
			return PartialView();
		}

		public ActionResult GetSupportedMiddleware()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportedMiddleware = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportedMiddleware)
			{
				model.SupportedMiddlewareYes = Convert.ToInt32(item.SupportedMiddlewareYes);
				model.SupportedMiddlewareNo = Convert.ToInt32(item.SupportedMiddlewareNo);
				model.SupportedMiddlewareWarning = Convert.ToInt32(item.SupportedMiddlewareWarning);
				model.SupportedMiddlewareOverRall = Convert.ToInt32(item.SupportedMiddlewareOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
		
		public ActionResult SupportedDatabase()
		{
			return PartialView();
		}

		public ActionResult GetSupportedDatabase()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportedDatabase = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportedDatabase)
			{
				model.SupportedDatabaseYes = Convert.ToInt32(item.SupportedDatabaseYes);
				model.SupportedDatabaseNo = Convert.ToInt32(item.SupportedDatabaseNo);
				model.SupportedDatabaseWarning = Convert.ToInt32(item.SupportedDatabaseWarning);
				model.SupportedDatabaseOverRall = Convert.ToInt32(item.SupportedDatabaseOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		} 

		public ActionResult OpenVulnerabilities()
		{
			return PartialView();
		}

		public ActionResult GetOpenVulnerabilities()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var openVulnerabilities = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in openVulnerabilities)
			{
				model.OpenVulnerabilitiesYes = Convert.ToInt32(item.OpenVulnerabilitiesYes);
				model.OperationalMonitoringNo = Convert.ToInt32(item.OperationalMonitoringNo);
				model.OperationalMonitoringWarning = Convert.ToInt32(item.OperationalMonitoringWarning);
				model.OperationalMonitoringOverRall = Convert.ToInt32(item.OperationalMonitoringOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
	}
}