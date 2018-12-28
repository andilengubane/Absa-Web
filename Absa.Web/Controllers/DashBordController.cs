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

		public ActionResult HighAvailabilty()
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

		public ActionResult SPOF()
		{
			return PartialView();
		}
		public ActionResult GetSPOFData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var sPOFData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in sPOFData)
			{
				model.SPOFYes = Convert.ToInt32(item.SPOFYes);
				model.SPOFNo = Convert.ToInt32(item.SPOFNo);
				model.SPOFWarning = Convert.ToInt32(item.SPOFWarning);
				model.SPOFOverRall = Convert.ToInt32(item.SPOFOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult HighDataClassification()
		{
			return PartialView();
		}
		public ActionResult GetHighDataClassificationData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var highDataClassificationData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in highDataClassificationData)
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
		public ActionResult GetDataRetentionRequirementData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var dataRetentionRequirementData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in dataRetentionRequirementData)
			{
				model.DataRetentionRequirementYes = Convert.ToInt32(item.DataRetentionRequirementYes);
				model.DataRetentionRequirementNo = Convert.ToInt32(item.DataRetentionRequirementNo);
				model.DataRetentionRequirementWarning = Convert.ToInt32(item.DataRetentionRequirementWarning);
				model.DataRetentionRequirementOverRall= Convert.ToInt32(item.DataRetentionRequirementOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult OperationMonitoring()
		{
			return PartialView();
		}
		public ActionResult GetOperationMonitoringData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var operationMonitoringData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in operationMonitoringData)
			{
				model.OparationsDocumentationYes = Convert.ToInt32(item.OparationsDocumentationYes);
				model.OperationalMonitoringNo = Convert.ToInt32(item.OperationalMonitoringNo);
				model.OparationsDocumentationWarning = Convert.ToInt32(item.OparationsDocumentationWarning);
				model.OparationsDocumentationOverRall = Convert.ToInt32(item.OparationsDocumentationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SecurityMonitoring()
		{
			return PartialView();
		}
		public ActionResult GetSecurityMonitoringData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var securityMonitoringData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in securityMonitoringData)
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
		public ActionResult GetInternalOLAData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var internalOLAData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in internalOLAData)
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
		public ActionResult GetExternalSLAData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var externalSLAData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in externalSLAData)
			{
				model.ExternalSLAYes = Convert.ToInt32(item.ExternalSLAYes);
				model.ExternalSLANo = Convert.ToInt32(item.ExternalSLANo);
				model.ExternalSLAWarning = Convert.ToInt32(item.ExternalSLAWarning);
				model.ExternalSLAOverRall = Convert.ToInt32(item.ExternalSLAOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult ArchitectureDocumentation()
		{
			return PartialView();
		}
		public ActionResult GetArchitectureDocumentationData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var architectureDocumentationData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in architectureDocumentationData)
			{
				model.ArchitectureDocumentationYes = Convert.ToInt32(item.ArchitetureDocumentationYes);
				model.ArchitectureDocumentationNo = Convert.ToInt32(item.ArchitetureDocumentationNo);
				model.ArchitectureDocumentationWarning = Convert.ToInt32(item.ArchitetureDocumentationWarning);
				model.ArchitectureDocumentationOverRall = Convert.ToInt32(item.ArchitetureDocumentationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult OparetionalDocumentation()
		{
			return PartialView();
		}
		public ActionResult GetOparetionalDocumentationData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var oparetionalDocumentationData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in oparetionalDocumentationData)
			{
				model.OparationsDocumentationYes = Convert.ToInt32(item.OparationsDocumentationYes);
				model.OparationsDocumentationNo = Convert.ToInt32(item.OparationsDocumentationNo);
				model.OparationsDocumentationWarning = Convert.ToInt32(item.OparationsDocumentationWarning);
				model.OparationsDocumentationOverRall = Convert.ToInt32(item.OparationsDocumentationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult IntegrateToAD()
		{
			return PartialView();
		}
		public ActionResult GetIntegrateToADData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var integrateToADData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in integrateToADData)
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
		public ActionResult GetJMLProcessData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var jMLProcessData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in jMLProcessData)
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
		public ActionResult GetRecertificationProcessData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var recertificationProcessData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in recertificationProcessData)
			{
				model.RecertificationProcessYes = Convert.ToInt32(item.RecertificationProcessYes);
				model.RecertificationProcessNo = Convert.ToInt32(item.RecertificationProcessNo);
				model.RecertificationProcessWarning = Convert.ToInt32(item.RecertificationProcessWarning);
				model.RecertificationProcessOverRall = Convert.ToInt32(item.RecertificationProcessOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult PrevilegedAccessManagement()
		{
			return PartialView();
		}
		public ActionResult GetPrevilegedAccessManagementData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var previlegedAccessManagementData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in previlegedAccessManagementData)
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
		public ActionResult GetOSPatchingLevelData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var oSPatchingLevelData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in oSPatchingLevelData)
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
		public ActionResult GetApplicationPatchingLevelData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var applicationPatchingLevelData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in applicationPatchingLevelData)
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
		public ActionResult GetMiddlewarePatchingLevelData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var middlewarePatchingLevelData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in middlewarePatchingLevelData)
			{
				model.MiddlewarePatchingLevelYes = Convert.ToInt32(item.MiddlewarePatchingLevelYes);
				model.MiddlewarePatchingLevelNo = Convert.ToInt32(item.MiddlewarePatchingLevelNo);
				model.MiddlewarePatchingLevelWarning = Convert.ToInt32(item.MiddlewarePatchingLevelWarning);
				model.MiddlewarePatchingLevelOverRall = Convert.ToInt32(item.MiddlewarePatchingLevelOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportApplication()
		{
			return PartialView();
		}
		public ActionResult GetSupportApplicationDataData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportApplicationData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportApplicationData)
			{
				model.SupportedApplicationYes = Convert.ToInt32(item.SupportedApplicationYes);
				model.SupportedApplicationNo = Convert.ToInt32(item.SupportedApplicationNo);
				model.SupportedApplicationWarning = Convert.ToInt32(item.SupportedApplicationWarning);
				model.SupportedApplicationOverRall = Convert.ToInt32(item.SupportedApplicationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportOS()
		{
			return PartialView();
		}
		public ActionResult GetSupportOSData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportOSData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportOSData)
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
		public ActionResult GetsupportJavaData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportJavaData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportJavaData)
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
		public ActionResult GetSupportedMiddlewareData()
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
				model.SupportedOperationSystemOverRall = Convert.ToInt32(item.SupportedOperationSystemOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult SupportedDatabase()
		{
			return PartialView();
		}
		public ActionResult GetSupportedDatabaseData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var supportedDatabaseData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in supportedDatabaseData)
			{
				model.SupportedMiddlewareYes = Convert.ToInt32(item.SupportedMiddlewareYes);
				model.SupportedMiddlewareNo = Convert.ToInt32(item.SupportedMiddlewareNo);
				model.SupportedMiddlewareWarning = Convert.ToInt32(item.SupportedMiddlewareWarning);
				model.SupportedOperationSystemOverRall = Convert.ToInt32(item.SupportedOperationSystemOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}

		public ActionResult OpenVulnerabilities()
		{
			return PartialView();
		}
		public ActionResult GetOpenVulnerabilitiesData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var openVulnerabilitiesData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in openVulnerabilitiesData)
			{
				model.OpenVulnerabilitiesYes = Convert.ToInt32(item.OpenVulnerabilitiesYes);
				model.OpenVulnerabilitiesNo = Convert.ToInt32(item.OpenVulnerabilitiesNo);
				model.OpenVulnerabilitiesWarning = Convert.ToInt32(item.OpenVulnerabilitiesWarning);
				model.OpenVulnerabilitiesOverRall = Convert.ToInt32(item.OpenVulnerabilitiesOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
	}
}