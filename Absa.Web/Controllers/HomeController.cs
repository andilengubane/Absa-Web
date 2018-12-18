using System;
using PagedList;
using System.Web;
using System.Linq;
using PagedList.Mvc;
using System.Web.Mvc;
using Absa.Web.Models;
using Absa.DateAccess;
using System.Collections.Generic;

namespace Absa.Web.Controllers
{
	public class HomeController : Controller
	{
		AbsaDBEntities context = new AbsaDBEntities();
		public ActionResult Index()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);

			var model = new DashBord();
			model.BusinessUnitList = context.BusinessUnits.Where(x => x.BusinessUnitId == data.BusinessUnitId).Select(x => new SelectListItem
			{
				Value = x.BusinessUnitId.ToString(),
				Text = x.BusinessUnitName
			});
			
			var strategicFitappData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitappData)
			{
				this.ViewBag.StrategicFitYes = item.StrategicFitYes;
				this.ViewBag.StrategicFitNo = item.StrategicFitNo;
				this.ViewBag.StrategicFitWarning = item.StrategicFitWarning;

				this.ViewBag.DisasterRecoverYes = item.DisasterRecoverYes;
				this.ViewBag.DisasterRecoverNo = item.DisasterRecoverNo;
				this.ViewBag.DisasterRecoverWarning = item.DisasterRecoverWarning;

				this.ViewBag.BackUpDataYes = item.BackUpDataYes;
				this.ViewBag.BackUpDataNo = item.BackUpDataNo;
				this.ViewBag.BackUpDataWarning = item.BackUpDataWarning;

				this.ViewBag.BackUpConfigurationYes = item.BackUpConfigurationYes;
				this.ViewBag.BackUpConfigurationNo = item.BackUpConfigurationNo;
				this.ViewBag.BackUpConfigurationWarning = item.BackUpConfigurationWarning;

				this.ViewBag.HighAvailabilityYes = item.HighAvailabilityYes;
				this.ViewBag.HighAvailabilityNo = item.HighAvailabilityNo;
				this.ViewBag.HighAvailabilityWarning = item.HighAvailabilityWarning;

				this.ViewBag.OperationalMonitoringYes = item.OperationalMonitoringYes;
				this.ViewBag.OperationalMonitoringNo = item.OperationalMonitoringNo;
				this.ViewBag.OperationalMonitoringWarning = item.OperationalMonitoringWarning;

				this.ViewBag.SecurityMonitoringYes = item.SecurityMonitoringYes;
				this.ViewBag.SecurityMonitoringNo = item.SecurityMonitoringNo;
				this.ViewBag.SecurityMonitoringWarning = item.SecurityMonitoringWarning;

				this.ViewBag.SPOFYes = item.SPOFYes;
				this.ViewBag.SPOFNo = item.SPOFNo;
				this.ViewBag.SPOFWarning = item.SPOFWarning;

				this.ViewBag.InternalOLAYes = item.InternalOLAYes;
				this.ViewBag.InternalOLANo = item.InternalOLANo;
				this.ViewBag.InternalOLAWarning = item.InternalOLAWarning;

				this.ViewBag.ExternalSLAYes = item.ExternalSLAYes;
				this.ViewBag.ExternalSLANo = item.ExternalSLANo;
				this.ViewBag.ExternalSLAWarning = item.ExternalSLAWarning;

				this.ViewBag.ArchitetureDocumentationYes = item.ArchitetureDocumentationYes;
				this.ViewBag.ArchitetureDocumentationNo = item.ArchitetureDocumentationNo;
				this.ViewBag.ArchitetureDocumentationWarning = item.ArchitetureDocumentationWarning;

				this.ViewBag.OparationsDocumentationYes = item.OparationsDocumentationYes;
				this.ViewBag.OparationsDocumentationNo = item.OparationsDocumentationNo;
				this.ViewBag.OparationsDocumentationWarning = item.OparationsDocumentationWarning;
				
				this.ViewBag.HighestDataClassificationYes = item.HighestDataClassificationYes;
				this.ViewBag.HighestDataClassificationNo = item.HighestDataClassificationNo;
				this.ViewBag.HighestDataClassificationWarning = item.HighestDataClassificationWarning;

				this.ViewBag.DataRetentionRequirementYes = item.DataRetentionRequirementYes;
				this.ViewBag.DataRetentionRequirementNo = item.DataRetentionRequirementNo;
				this.ViewBag.DataRetentionRequirementWarning = item.DataRetentionRequirementWarning;
				
				this.ViewBag.IntegratedToADYes = item.IntegratedToADYes;
				this.ViewBag.IntegratedToADNo = item.IntegratedToADNo;
				this.ViewBag.IntegratedToADWarning = item.IntegratedToADWarning;

				this.ViewBag.JMLProcessYes = item.JMLProcessYes;
				this.ViewBag.JMLProcessNo = item.JMLProcessNo;
				this.ViewBag.JMLProcessWarning = item.JMLProcessWarning;

				this.ViewBag.PrivilegedAccessManagementYes = item.PrivilegedAccessManagementYes;
				this.ViewBag.PrivilegedAccessManagementNo = item.PrivilegedAccessManagementNo;
				this.ViewBag.PrivilegedAccessManagementWarning = item.PrivilegedAccessManagementWarning;

				this.ViewBag.RecertificationProcessYes = item.RecertificationProcessYes;
				this.ViewBag.RecertificationProcessNo = item.RecertificationProcessNo;
				this.ViewBag.RecertificationProcessWarning = item.RecertificationProcessWarning;

				this.ViewBag.OSPatchingLevelYes = item.OSPatchingLevelYes;
				this.ViewBag.OSPatchingLevelNo = item.OSPatchingLevelNo;
				this.ViewBag.OSPatchingLevelWarning = item.OSPatchingLevelWarning;

				this.ViewBag.ApplicationPatchingLevelYes = item.ApplicationPatchingLevelYes;
				this.ViewBag.ApplicationPatchingLevelNo = item.ApplicationPatchingLevelNo;
				this.ViewBag.ApplicationPatchingLevelWarning = item.ApplicationPatchingLevelWarning;

				this.ViewBag.MiddlewarePatchingLevelYes = item.MiddlewarePatchingLevelYes;
				this.ViewBag.MiddlewarePatchingLevelNo = item.MiddlewarePatchingLevelNo;
				this.ViewBag.MiddlewarePatchingLevelWarning = item.MiddlewarePatchingLevelWarning;

				this.ViewBag.SupportedApplicationYes = item.SupportedApplicationYes;
				this.ViewBag.SupportedApplicationNo = item.SupportedApplicationNo;
				this.ViewBag.SupportedApplicationWarning = item.SupportedApplicationWarning;

				this.ViewBag.SupportedOperationSystemYes = item.SupportedOperationSystemYes;
				this.ViewBag.SupportedOperationSystemNo = item.SupportedOperationSystemNo;
				this.ViewBag.SupportedOperationSystemWarning = item.SupportedOperationSystemWarning;

				this.ViewBag.SupportedJavaYes = item.SupportedJavaYes;
				this.ViewBag.SupportedJavaNo = item.SupportedJavaNo;
				this.ViewBag.SupportedJavaWarning = item.SupportedJavaWarning;

				this.ViewBag.SupportedMiddlewareYes = item.SupportedMiddlewareYes;
				this.ViewBag.SupportedMiddlewareNo = item.SupportedMiddlewareNo;
				this.ViewBag.SupportedMiddlewareWarning = item.SupportedMiddlewareWarning;

				this.ViewBag.SupportedDatabaseYes = item.SupportedDatabaseYes;
				this.ViewBag.SupportedDatabaseNo = item.SupportedDatabaseNo;
				this.ViewBag.SupportedDatabaseWarning = item.SupportedDatabaseWarning;

				this.ViewBag.OpenVulnerabilitiesYes = item.OpenVulnerabilitiesYes;
				this.ViewBag.OpenVulnerabilitiesNo = item.OpenVulnerabilitiesNo;
				this.ViewBag.OpenVulnerabilitiesWarning = item.OpenVulnerabilitiesWarning;
			}
			return View(model);
		}

		public ActionResult Report()
		{
			return PartialView();
		}
		public ActionResult Reports()
		{
			return PartialView();
		}

		public ActionResult GetStrategicFitData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new ReportViewModel();
			
			var strategicFitappData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitappData)
			{
				model.StrategicFitYes = Convert.ToInt32(item.StrategicFitYes);
				model.StrategicFitNo = Convert.ToInt32(item.StrategicFitNo);
				model.StrategicFitWarning = Convert.ToInt32(item.StrategicFitWarning);
			}
			return Json(model,JsonRequestBehavior.AllowGet);
		}

		// Get Create
		public ActionResult Create()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);

			var model = new ResilienceTrackModel();
			model.StatusList = context.DataLookUps.Where(x => x.LoopkUpID == 1).Select(x => new SelectListItem
			{
				Value = x.Description,
				Text = x.Description
			});
			
			return PartialView(model);
		}

		// Get EditResilienceTrack
		public ActionResult EditResilienceTrack(string resilienceTrackId)
		{
			var _Id = this.Session["ID"];
			int userId = Convert.ToInt32(_Id);
			var dataStatus = context.Users.FirstOrDefault(u => u.UserID == userId);

			var model = new ResilienceTrackModel();
			string number = System.Text.RegularExpressions.Regex.Replace(resilienceTrackId, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);

			if (id != 0)
			{
				try
				{
					var data = context.ResilienceTracks.Where(m => m.ResilienceTrackID == id && m.BusinessUnitId == dataStatus.BusinessUnitId);
					foreach (var result in data)
					{
						model.ResilienceTrackID = result.ResilienceTrackID;
						model.ApplicationID = result.ApplicationID;
						model.ApplicationName = result.ApplicationName;
						model.NameOnSnow = result.NameOnSnow;
						model.Tiering = result.Tiering.Value;
						model.HeadOfTechnology = result.HeadOfTechnology;
						model.ApplicatioOwner = result.ApplicatioOwner;
						model.ServiceManager = result.ServiceManager;
						model.StrategicFit = result.StrategicFit;
	                    model.DisasterRecovery  = result.DisasterRecovery;
	                    model.BackUpData  = result.BackUpData;
	                    model.BackUpConfiguration  = result.BackUpConfiguration;
	                    model.HighAvailability  = result.HighAvailability;
	                    model.SPOF  = result.SPOF;
	                    model.OperationalMonitoring  = result.OperationalMonitoring;
	                    model.SecurityMonitoring  = result.SecurityMonitoring;
	                    model.InternalOLA  = result.InternalOLA;
	                    model.ExternalSLA  = result.ExternalSLA;
	                    model.ArchitetureDocumentation  = result.ArchitetureDocumentation;
	                    model.OparationsDocumentation  = result.OparationsDocumentation;
	                    model.HighestDataClassification  = result.HighestDataClassification;
	                    model.DataRetentionRequirement  = result.DataRetentionRequirement;
	                    model.IntegratedToAD  = result.IntegratedToAD;
	                    model.JMLProcess  = result.JMLProcess;
	                    model.RecertificationProcess  = result.RecertificationProcess;
	                    model.PrivilegedAccessManagement  = result.PrivilegedAccessManagement;
	                    model.OSPatchingLevel  = result.OSPatchingLevel;
	                    model.ApplicationPatchingLevel  = result.ApplicationPatchingLevel;
	                    model.MiddlewarePatchingLevel  = result.MiddlewarePatchingLevel;
	                    model.SupportedApplication  = result.SupportedApplication;
	                    model.SupportedOperationSystem  = result.SupportedOperationSystem;
	                    model.SupportedJava  = result.SupportedJava;
	                    model.SupportedMiddleware  = result.SupportedMiddleware;
	                    model.SupportedDatabase  = result.SupportedDatabase;
	                    model.OpenVulnerabilities  = result.OpenVulnerabilities;
					}
				}
				catch (Exception ex)
				{
					var error = ex.Message;
				}

				model.StatusList = context.DataLookUps.Where(x => x.LoopkUpID == 1).Select(x => new SelectListItem
				{
					Value = x.Description,
					Text = x.Description
				});
			
			}
			return PartialView(model);
		}

		// Get: Resilience Track List
		public ActionResult ResiliencTrackList(int? page, string currentFilter, string searchString)
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var model = new List<ResilienceTrackModel>();
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}
			try
			{
				var businessUnitData = context.Users.FirstOrDefault(u => u.UserID == userId);
				var data = from s in context.ResilienceTracks
						   where s.BusinessUnitId == businessUnitData.BusinessUnitId
						   select s;
				ViewBag.CurrentFilter = searchString;
				if (!String.IsNullOrEmpty(searchString))
				{
					data = data.Where(s => s.ApplicationID.Contains(searchString)); 
				}
				foreach (var item in data)
				{
					model.Add(new ResilienceTrackModel()
					{
						ResilienceTrackID = item.ResilienceTrackID,
						ApplicationID = item.ApplicationID,
						ApplicationName = item.ApplicationName,
						NameOnSnow = item.NameOnSnow,
						HeadOfTechnology = item.HeadOfTechnology,
						ApplicatioOwner = item.ApplicatioOwner,
						ServiceManager = item.ServiceManager,
						Tiering = item.Tiering.Value,
					});
				}
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}

			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return this.View("ResiliencTrackList", model.ToPagedList(pageNumber, pageSize));
		}

		// Get: Edit User
		public ActionResult Approval(string resilienceTrackId)
		{
			var model = new List<ResilienceTrackModel>();
			string number = System.Text.RegularExpressions.Regex.Replace(resilienceTrackId, @"\D+", string.Empty);
			int id = Convert.ToInt32(number);
			try
			{
				var data = context.GetResilienceTrackListById(id);
				foreach (var item in data)
				{
					model.Add(new ResilienceTrackModel()
					{
						ResilienceTrackID = item.ResilienceTrackID,
						StrategicFit = item.StrategicFit,
						DisasterRecovery = item.DisasterRecovery,
						BackUpData = item.BackUpData,
						BackUpConfiguration = item.BackUpConfiguration,
						HighAvailability = item.HighAvailability,
						SPOF = item.SPOF,
						OperationalMonitoring = item.OperationalMonitoring,
						SecurityMonitoring = item.SecurityMonitoring,
						InternalOLA = item.InternalOLA,
						ExternalSLA = item.ExternalSLA,
						ArchitetureDocumentation = item.ArchitetureDocumentation,
						OparationsDocumentation = item.OparationsDocumentation,
						HighestDataClassification = item.HighestDataClassification,
						DataRetentionRequirement = item.DataRetentionRequirement,
						IntegratedToAD = item.IntegratedToAD,
						JMLProcess = item.JMLProcess,
						RecertificationProcess = item.RecertificationProcess,
						PrivilegedAccessManagement = item.PrivilegedAccessManagement,
						OSPatchingLevel = item.OSPatchingLevel,
						ApplicationPatchingLevel = item.ApplicationPatchingLevel,
						MiddlewarePatchingLevel = item.MiddlewarePatchingLevel,
						SupportedApplication = item.SupportedApplication,
						SupportedOperationSystem = item.SupportedOperationSystem,
						SupportedJava = item.SupportedJava,
						SupportedMiddleware = item.SupportedMiddleware,
						SupportedDatabase = item.SupportedDatabase,
						OpenVulnerabilities = item.OpenVulnerabilities,
					});
				}
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}
			return PartialView("Approval", model);
		}

		// Post AddUpdateResilienceTrack
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult AddUpdateResilienceTrack(ResilienceTrackModel model)
		{
			if (model.ResilienceTrackID == 0)
			{
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);
				var data = context.Users.FirstOrDefault(u => u.UserID == userId);
				context.ResilienceTracks.Add(new ResilienceTrack
				{
					ResilienceTrackID = model.ResilienceTrackID,
					ApplicationID = model.ApplicationID,
					UserID = model.UserID,
					ApplicationName = model.ApplicationName,
					NameOnSnow = model.NameOnSnow,
					Tiering = model.Tiering,
					HeadOfTechnology = model.HeadOfTechnology,
					BusinessUnitId = data.BusinessUnitId,
					ApplicatioOwner = model.ApplicatioOwner,
					ServiceManager = model.ServiceManager,
					StrategicFit = model.StrategicFit,
					DisasterRecovery = model.DisasterRecovery,
					BackUpData = model.BackUpData,
					BackUpConfiguration = model.BackUpConfiguration,
					HighAvailability = model.HighAvailability,
					SPOF = model.SPOF,
					OperationalMonitoring = model.OperationalMonitoring,
					SecurityMonitoring = model.SecurityMonitoring,
					InternalOLA = model.InternalOLA,
					ExternalSLA = model.ExternalSLA,
					ArchitetureDocumentation = model.ArchitetureDocumentation,
					OparationsDocumentation = model.OparationsDocumentation,
					HighestDataClassification = model.HighestDataClassification,
					DataRetentionRequirement = model.DataRetentionRequirement,
					IntegratedToAD = model.IntegratedToAD,
					JMLProcess = model.JMLProcess,
					RecertificationProcess = model.RecertificationProcess,
					PrivilegedAccessManagement = model.PrivilegedAccessManagement,
					OSPatchingLevel = model.OSPatchingLevel,
					ApplicationPatchingLevel = model.ApplicationPatchingLevel,
					MiddlewarePatchingLevel = model.MiddlewarePatchingLevel,
					SupportedApplication = model.SupportedApplication,
					SupportedOperationSystem = model.SupportedOperationSystem,
					SupportedJava = model.SupportedJava,
					SupportedMiddleware = model.SupportedMiddleware,
					SupportedDatabase = model.SupportedDatabase,
					OpenVulnerabilities = model.OpenVulnerabilities,
				});
			}
			else {

				var data = context.ResilienceTracks.FirstOrDefault(x => x.ResilienceTrackID == model.ResilienceTrackID);
				data.Tiering = model.Tiering;
				data.UserID = model.UserID;
				data.HeadOfTechnology = model.HeadOfTechnology;
				data.ServiceManager = model.ServiceManager;
				data.ApplicatioOwner = model.ApplicatioOwner;
				data.StrategicFit = model.StrategicFit;
				data.DisasterRecovery = model.DisasterRecovery;
				data.BackUpData = model.BackUpData;
				data.BackUpConfiguration = model.BackUpConfiguration;
				data.HighAvailability = model.HighAvailability;
				data.SPOF = model.SPOF;
				data.OperationalMonitoring = model.OperationalMonitoring;
				data.SecurityMonitoring = model.SecurityMonitoring;
				data.InternalOLA = model.InternalOLA;
				data.ExternalSLA = model.ExternalSLA;
				data.ArchitetureDocumentation = model.ArchitetureDocumentation;
				data.OparationsDocumentation = model.OparationsDocumentation;
				data.HighestDataClassification = model.HighestDataClassification;
				data.DataRetentionRequirement = model.DataRetentionRequirement;
				data.IntegratedToAD = model.IntegratedToAD;
				data.JMLProcess = model.JMLProcess;
				data.RecertificationProcess = model.RecertificationProcess;
				data.PrivilegedAccessManagement = model.PrivilegedAccessManagement;
				data.OSPatchingLevel = model.OSPatchingLevel;
				data.ApplicationPatchingLevel = model.ApplicationPatchingLevel;
				data.MiddlewarePatchingLevel = model.MiddlewarePatchingLevel;
				data.SupportedApplication = model.SupportedApplication;
				data.SupportedOperationSystem = model.SupportedOperationSystem;
				data.SupportedJava = model.SupportedJava;
				data.SupportedMiddleware = model.SupportedMiddleware;
				data.SupportedDatabase = model.SupportedDatabase;
				data.OpenVulnerabilities = model.OpenVulnerabilities;
			}
			context.SaveChanges();
			return RedirectToAction("ResiliencTrackList", "Home");
		}
	}
}