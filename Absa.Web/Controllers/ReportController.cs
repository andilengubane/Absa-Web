using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.DTO;
using Absa.Web.Models;
namespace Absa.Web.Controllers
{
    public class ReportController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
		
		public ActionResult OverRallReportView()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new ReportDTO();

			model.BusinessUnitList = context.BusinessUnits.Where(x => x.BusinessUnitId == data.BusinessUnitId).Select(x => new SelectListItem
			{
				Value = x.BusinessUnitId.ToString(),
				Text = x.BusinessUnitName
			});
			return PartialView(model);
		}

		public ActionResult GetAllAppStatus()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);

			var model = new DashBordModel();
			var strategicFitappData = context.GetApplicationByBusinesUnitId(data.BusinessUnitId);

			foreach (var item in strategicFitappData)
			{
				model.StrategicFitYes = Convert.ToInt32(item.StrategicFitYes);
				model.StrategicFitNo = Convert.ToInt32(item.StrategicFitNo);
				model.StrategicFitWarning = Convert.ToInt32(item.StrategicFitWarning);

				model.DisasterRecoveryYes = Convert.ToInt32(item.DisasterRecoverYes);
				model.DisasterRecoveryNo = Convert.ToInt32(item.DisasterRecoverNo);
				model.DisasterRecoveryWarning = Convert.ToInt32(item.DisasterRecoverWarning);

				model.BackUpDataYes = Convert.ToInt32(item.BackUpDataYes);
				model.BackUpDataNo = Convert.ToInt32(item.BackUpDataNo);
				model.BackUpDataWarning = Convert.ToInt32(item.BackUpDataWarning);

				model.BackUpConfigurationYes = Convert.ToInt32(item.BackUpConfigurationYes);
				model.BackUpConfigurationNo = Convert.ToInt32(item.BackUpConfigurationNo);
				model.BackUpConfigurationWarning = Convert.ToInt32(item.BackUpConfigurationWarning);

				model.HighAvailabilityYes = Convert.ToInt32(item.HighAvailabilityYes);
				model.HighAvailabilityNo = Convert.ToInt32(item.HighAvailabilityNo);
				model.HighAvailabilityWarning = Convert.ToInt32(item.HighAvailabilityWarning);

				model.OperationalMonitoringYes = Convert.ToInt32(item.OperationalMonitoringYes);
				model.OperationalMonitoringNo = Convert.ToInt32(item.OperationalMonitoringNo);
				model.OperationalMonitoringWarning = Convert.ToInt32(item.OperationalMonitoringWarning);

				model.SecurityMonitoringYes = Convert.ToInt32(item.SecurityMonitoringYes);
				model.SecurityMonitoringNo = Convert.ToInt32(item.SecurityMonitoringNo);
				model.SecurityMonitoringWarning = Convert.ToInt32(item.SecurityMonitoringWarning);

				model.SPOFYes = Convert.ToInt32(item.SPOFYes);
				model.SPOFNo = Convert.ToInt32(item.SPOFNo);
				model.SPOFWarning = Convert.ToInt32(item.SPOFWarning);

				model.InternalOLAYes = Convert.ToInt32(item.InternalOLAYes);
				model.InternalOLANo = Convert.ToInt32(item.InternalOLANo);
				model.InternalOLAWarning = Convert.ToInt32(item.InternalOLAWarning);

				model.ExternalSLAYes = Convert.ToInt32(item.ExternalSLAYes);
				model.ExternalSLANo = Convert.ToInt32(item.ExternalSLANo);
				model.ExternalSLAWarning = Convert.ToInt32(item.ExternalSLAWarning);

				model.ArchitectureDocumentationYes = Convert.ToInt32(item.ArchitetureDocumentationYes);
				model.ArchitectureDocumentationNo = Convert.ToInt32(item.ArchitetureDocumentationNo);
				model.ArchitectureDocumentationWarning = Convert.ToInt32(item.ArchitetureDocumentationWarning);

				model.OparationsDocumentationYes = Convert.ToInt32(item.OparationsDocumentationYes);
				model.OparationsDocumentationNo = Convert.ToInt32(item.OparationsDocumentationNo);
				model.OparationsDocumentationWarning = Convert.ToInt32(item.OparationsDocumentationWarning);

				model.HighestDataClassificationYes = Convert.ToInt32(item.HighestDataClassificationYes);
				model.HighestDataClassificationNo = Convert.ToInt32(item.HighestDataClassificationNo);
				model.HighestDataClassificationWarning = Convert.ToInt32(item.HighestDataClassificationWarning);

				model.DataRetentionRequirementYes = Convert.ToInt32(item.DataRetentionRequirementYes);
				model.DataRetentionRequirementNo = Convert.ToInt32(item.DataRetentionRequirementNo);
				model.DataRetentionRequirementWarning = Convert.ToInt32(item.DataRetentionRequirementWarning);

				model.IntegratedToADYes = Convert.ToInt32(item.IntegratedToADYes);
				model.IntegratedToADNo = Convert.ToInt32(item.IntegratedToADNo);
				model.IntegratedToADWarning = Convert.ToInt32(item.IntegratedToADWarning);

				model.JMLProcessYes = Convert.ToInt32(item.JMLProcessYes);
				model.JMLProcessNo = Convert.ToInt32(item.JMLProcessNo);
				model.JMLProcessWarning = Convert.ToInt32(item.JMLProcessWarning);

				model.PrivilegedAccessManagementYes = Convert.ToInt32(item.PrivilegedAccessManagementYes);
				model.PrivilegedAccessManagementNo = Convert.ToInt32(item.PrivilegedAccessManagementNo);
				model.PrivilegedAccessManagementWarning = Convert.ToInt32(item.PrivilegedAccessManagementWarning);

				model.RecertificationProcessYes = Convert.ToInt32(item.RecertificationProcessYes);
				model.RecertificationProcessNo = Convert.ToInt32(item.RecertificationProcessNo);
				model.RecertificationProcessWarning = Convert.ToInt32(item.RecertificationProcessWarning);

				model.OSPatchingLevelYes = Convert.ToInt32(item.OSPatchingLevelYes);
				model.OSPatchingLevelNo = Convert.ToInt32(item.OSPatchingLevelNo);
				model.OSPatchingLevelWarning = Convert.ToInt32(item.OSPatchingLevelWarning);

				model.ApplicationPatchingLevelYes = Convert.ToInt32(item.ApplicationPatchingLevelYes);
				model.ApplicationPatchingLevelNo = Convert.ToInt32(item.ApplicationPatchingLevelNo);
				model.ApplicationPatchingLevelWarning = Convert.ToInt32(item.ApplicationPatchingLevelWarning);

				model.MiddlewarePatchingLevelYes = Convert.ToInt32(item.MiddlewarePatchingLevelYes);
				model.MiddlewarePatchingLevelNo = Convert.ToInt32(item.MiddlewarePatchingLevelNo);
				model.MiddlewarePatchingLevelWarning = Convert.ToInt32(item.MiddlewarePatchingLevelWarning);

				model.SupportedApplicationYes = Convert.ToInt32(item.SupportedApplicationYes);
				model.SupportedApplicationNo = Convert.ToInt32(item.SupportedApplicationNo);
				model.SupportedApplicationWarning = Convert.ToInt32(item.SupportedApplicationWarning);

				model.SupportedOperationSystemYes = Convert.ToInt32(item.SupportedOperationSystemYes);
				model.SupportedOperationSystemNo = Convert.ToInt32(item.SupportedOperationSystemNo);
				model.SupportedOperationSystemWarning = Convert.ToInt32(item.SupportedOperationSystemWarning);

				model.SupportedJavaYes = Convert.ToInt32(item.SupportedJavaYes);
				model.SupportedJavaNo = Convert.ToInt32(item.SupportedJavaNo);
				model.SupportedJavaWarning = Convert.ToInt32(item.SupportedJavaWarning);

				model.SupportedMiddlewareYes = Convert.ToInt32(item.SupportedMiddlewareYes);
				model.SupportedMiddlewareNo = Convert.ToInt32(item.SupportedMiddlewareNo);
				model.SupportedMiddlewareWarning = Convert.ToInt32(item.SupportedMiddlewareWarning);

				model.SupportedDatabaseYes = Convert.ToInt32(item.SupportedDatabaseYes); 
				model.SupportedDatabaseNo = Convert.ToInt32(item.SupportedDatabaseNo);
				model.SupportedDatabaseWarning = Convert.ToInt32(item.SupportedDatabaseWarning);

				model.OpenVulnerabilitiesYes = Convert.ToInt32(item.OpenVulnerabilitiesYes);
				model.OpenVulnerabilitiesNo = Convert.ToInt32(item.OpenVulnerabilitiesNo);
				model.OpenVulnerabilitiesWarning = Convert.ToInt32(item.OpenVulnerabilitiesWarning);

			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
	}
}