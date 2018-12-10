using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.Web.Models;
using Absa.DateAccess;

namespace Absa.Web.Controllers
{
	public class HomeController : Controller
	{
		AbsaDBEntities context = new AbsaDBEntities();
		public ActionResult Index()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var model = new DashBord()
			{
				BusinessUnitList = context.BusinessUnits.Select(x => new SelectListItem     
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				})
			};
			return View(model);
		}

		public ActionResult Create()
		{
			//APPL017023
			//var model = new ResilienceTrackModel();
			//DateTime dob = DateTime.Now;
			//string ApplicatioId = "APPL0" + dob.Day + dob.Month;
			//model.ApplicationID = ApplicatioId;
			return PartialView();
		}

		// Get EditResilienceTrack
		public ActionResult EditResilienceTrack(string resilienceTrackId)
		{
			var model = new ResilienceTrackModel();
			string number = System.Text.RegularExpressions.Regex.Replace(resilienceTrackId, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);
			var items = context.DataLookUps.Where(x => x.LoopkUpID == 1).ToList();
			if (items != null)
			{
				ViewBag.data = items;
			}
			if (id != 0)
			{
				try
				{
					var data = context.ResilienceTracks.Where(m => m.ResilienceTrackID == id);
					foreach (var result in data)
					{
						model.ResilienceTrackID = result.ResilienceTrackID;
						model.ApplicationID = result.ApplicationID;
						model.ApplicationName = result.ApplicationName;
						model.NameOnSnow = result.NameOnSnow;
						model.Tiering = result.Tiering.Value;
						model.HeadOfTechnology = result.HeadOfTechnology;
						model.ApplicatioOwner = result.ApplicatioOwner;
						model.HeadOfTechnology = result.ApplicatioOwner;
	              }
				}
				catch (Exception ex)
				{
					var error = ex.Message;
				}
				/*
				 	model.BusinestUnitList = context.BusinessUnits.OrderBy(x => x.BusinessUnitName).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				});

				model.RolesPermissionList = context.RolesPermissions.OrderBy(x => x.Type).Select(x => new SelectListItem
				{
					Value = x.RolesPermissionsID.ToString(),
					Text = x.Type
				});
				 */
			}
			return PartialView(model);
		}
		public ActionResult ResiliencTrackList()
		{
			var model = new List<ResilienceTrackModel>();
			try
			{
				var data = context.GetResilienceTrackList();

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
						BusinessUnit = item.BusinessUnitName
					});
				}
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}
			return this.View("ResiliencTrackList", model);
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
		public ActionResult AddUpdateResilienceTrack(ResilienceTrackModel model)
		{
			if (model.ResilienceTrackID == 0)
			{
				context.ResilienceTracks.Add(new ResilienceTrack
				{
					ResilienceTrackID = model.ResilienceTrackID,
				    ApplicationID = model.ApplicationID,
				    ApplicationName = model.ApplicationName,
				    NameOnSnow = model.NameOnSnow,
				    Tiering = model.Tiering,
				    HeadOfTechnology = model.HeadOfTechnology,
				    ApplicatioOwner = model.ApplicatioOwner,
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
			else
			{
				var data = context.ResilienceTracks.FirstOrDefault(x => x.ResilienceTrackID == model.ResilienceTrackID);
				data.ResilienceTrackID = model.ResilienceTrackID;
				data.ApplicationID = model.ApplicationID;
				data.ApplicationName = model.ApplicationName;
				data.NameOnSnow = model.NameOnSnow;
				data.Tiering = model.Tiering;
				data.HeadOfTechnology = model.HeadOfTechnology;
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
			return RedirectToAction("UserList", "Account");
		}
	}
}