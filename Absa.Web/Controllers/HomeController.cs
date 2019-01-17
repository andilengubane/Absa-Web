using System;
using PagedList;
using System.Web;
using System.Linq;
using PagedList.Mvc;
using System.Web.Mvc;
using System.Net.Mail;
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
			var model = new DashBordModel();
			var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
			var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
			string rolePermissionType = Convert.ToString(permissions.Type);

			if (rolePermissionType == "Manager")
			{
				model.BusinessUnitList = context.BusinessUnits.Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				});
			}
			else
			{
				model.BusinessUnitList = context.BusinessUnits.Where(x => x.BusinessUnitId == data.BusinessUnitId).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				});
			}

			

			return View(model);
		}

		public ActionResult GetDeshbordStatus()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);

			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var numberOfAppWithinTheBusinessUnit = context.BusinessUnits.FirstOrDefault(b=>b.BusinessUnitId == data.BusinessUnitId);
			
			var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
			var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
			string rolePermissionType = Convert.ToString(permissions.Type);

			var model = new DashBordModel();
			var appData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in appData)
			{
				model.StrategicFitYes = Convert.ToInt32(item.StrategicFitYes);
				model.DisasterRecoveryYes = Convert.ToInt32(item.DisasterRecoverYes);
				model.BackUpDataYes = Convert.ToInt32(item.BackUpDataYes);
				model.BackUpConfigurationYes = Convert.ToInt32(item.BackUpConfigurationYes);
				model.HighAvailabilityYes = Convert.ToInt32(item.HighAvailabilityYes);
				model.OperationalMonitoringYes = Convert.ToInt32(item.OperationalMonitoringYes);
				model.SecurityMonitoringYes = Convert.ToInt32(item.SecurityMonitoringYes);
				model.SPOFYes = Convert.ToInt32(item.SPOFYes);
				model.InternalOLAYes = Convert.ToInt32(item.InternalOLAYes);
				model.ExternalSLAYes = Convert.ToInt32(item.ExternalSLAYes);
				model.ArchitectureDocumentationYes = Convert.ToInt32(item.ArchitetureDocumentationYes);
				model.OparationsDocumentationYes = Convert.ToInt32(item.OparationsDocumentationYes);
				model.HighestDataClassificationYes = Convert.ToInt32(item.HighestDataClassificationYes);
				model.DataRetentionRequirementYes = Convert.ToInt32(item.DataRetentionRequirementYes);
				model.IntegratedToADYes = Convert.ToInt32(item.IntegratedToADYes);
				model.JMLProcessYes = Convert.ToInt32(item.JMLProcessYes);
				model.PrivilegedAccessManagementYes = Convert.ToInt32(item.PrivilegedAccessManagementYes);
				model.RecertificationProcessYes = Convert.ToInt32(item.RecertificationProcessYes);
				model.OSPatchingLevelYes = Convert.ToInt32(item.OSPatchingLevelYes);
				model.ApplicationPatchingLevelYes = Convert.ToInt32(item.ApplicationPatchingLevelYes);
				model.MiddlewarePatchingLevelYes = Convert.ToInt32(item.MiddlewarePatchingLevelYes);
				model.SupportedApplicationYes = Convert.ToInt32(item.SupportedApplicationYes);
				model.SupportedOperationSystemYes = Convert.ToInt32(item.SupportedOperationSystemYes);
				model.SupportedJavaYes = Convert.ToInt32(item.SupportedJavaYes);
				model.SupportedMiddlewareYes = Convert.ToInt32(item.SupportedMiddlewareYes);
				model.SupportedDatabaseYes = Convert.ToInt32(item.SupportedDatabaseYes);
				model.OpenVulnerabilitiesYes = Convert.ToInt32(item.OpenVulnerabilitiesYes);
				model.NumberOfApps = Convert.ToInt32(numberOfAppWithinTheBusinessUnit.NumberOfApps);

			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
		
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

		public ActionResult Decline(string resilienceTrackId)
		{
			string number = System.Text.RegularExpressions.Regex.Replace(resilienceTrackId, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);
			var model = new ApplicationModel();
			model.ApplicationDeclined = context.ResilinceApplications.Select(x => new SelectListItem
			{
				Value = x.ApplicationName.ToString(),
				Text = x.ApplicationName
			});

			var data = context.GetApplicationByResilienceID(id);
			foreach (var item in data)
			{
				model.ResilienceID = item.ResilienceTrackID;
				model.ApplicationId = item.ApplicationID;
				model.BusinessUnit = item.BusinessUnitName;
				model.FullName = item.FullName;
				model.Email = item.EmailAddress;
			}
			return PartialView(model);
		}

		public ActionResult DeclineRequest(ApplicationModel model)
		{
			int id = Convert.ToInt32(model.ResilienceID);
			var data = context.ResilienceTracks.FirstOrDefault(x => x.ResilienceTrackID == id);
			data.StatusId = 6;
			//SendEmail(model.Email, model.Description , model.BusinessUnit,model.ApplicationId,model.FullName,model.BusinessUnitName);
			context.SaveChanges();
			return RedirectToAction("ResiliencTrackList", "Home");
		}
		
		public ActionResult RequestApproved(string resilienceTrackId)
		{
			string number = System.Text.RegularExpressions.Regex.Replace(resilienceTrackId, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);
			var model = new ApplicationModel();

			var data = context.GetApplicationByResilienceID(id);
			foreach (var item in data)
			{
				model.ResilienceID = item.ResilienceTrackID;
				model.ApplicationId = item.ApplicationID;
				model.BusinessUnit = item.BusinessUnitName;
				model.FullName = item.FullName;
				model.Email = item.EmailAddress;
			}
			return PartialView(model);
		}

		public ActionResult UpdateRequestApproved(ApplicationModel model)
		{
			var data = context.ResilienceTracks.FirstOrDefault(x => x.ResilienceTrackID == model.ResilienceID);
			data.StatusId = 4;
			context.SaveChanges();
			return RedirectToAction("ResiliencTrackList", "Home");
		}

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
				var permission = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == businessUnitData.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permission.Type);
				ViewBag.RolePermission = rolePermissionType;

				var data = from s in context.GetResilienceTrackList()
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
						Description = item.Description,
						Tiering = item.Tiering.Value,
					});
				}
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}

			int pageSize = 10;
			int pageNumber = (page ?? 1);
			return this.View("ResiliencTrackList", model.ToPagedList(pageNumber, pageSize));
		}

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

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult AddUpdateResilienceTrack(ResilienceTrackModel model)
		{
			if (model.ResilienceTrackID == 0)
			{
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);
				var datas = context.Users.FirstOrDefault(u => u.UserID == userId);
				int statusId;
				var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
				var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permissions.Type);

				var Application = context.ResilienceTracks.FirstOrDefault(a => a.ApplicationID == model.ApplicationID && a.ApplicationName == model.ApplicationName);
				if (Application != null)
				{
					ViewBag.ErrorMessage = "Reasilience record with Application ID " + model.ApplicationID + " And Application Name " + model.ApplicationName + " already exist";
					return RedirectToAction("ResiliencTrackList", "Home");
				} else
				{
					if (rolePermissionType == "Manager")
					{
						statusId = 4;
					}
					else
					{
						statusId = 5;
					}

					context.ResilienceTracks.Add(new ResilienceTrack
					{
						ResilienceTrackID = model.ResilienceTrackID,
						ApplicationID = model.ApplicationID,
						UserID = userId,
						ApplicationName = model.ApplicationName,
						NameOnSnow = model.NameOnSnow,
						Tiering = model.Tiering,
						HeadOfTechnology = model.HeadOfTechnology,
						BusinessUnitId = datas.BusinessUnitId,
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
						StatusId = statusId
					});
				}
			}
			else {
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);
				int statusId;
				var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
				var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permissions.Type);

				if (rolePermissionType == "Manager"){
					 statusId = 4;
				}
				else {
					 statusId = 5;
				}

				var data = context.ResilienceTracks.FirstOrDefault(x => x.ResilienceTrackID == model.ResilienceTrackID);
				data.Tiering = model.Tiering;
				data.UserID = userId;
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
				data.StatusId = statusId;
			}
			context.SaveChanges();
			return RedirectToAction("ResiliencTrackList", "Home");
		}

		public void SendEmail(string email,string body, string businessUnit, string applicationID, string requestedBy, string applicationDeclined)
		{
			MailMessage msg = new MailMessage();
			msg.From = new MailAddress("mthembungubane@gmail.com");
			msg.To.Add(new MailAddress(email));
			msg.Subject = "Request Declined";
			msg.Body = "Business Unit" + businessUnit +
				       "\n" +"Application Id" + applicationID +
					   "\n"+"Approval Requested By" + requestedBy +
					   "\n"+ "Application Declined" + applicationDeclined +
					   "\n" + body;
			SmtpClient Client = new SmtpClient("smtp.gmail.com");
			Client.Port = 587;
			Client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mthembungubane@gmail.com", "andile1234!@#$");
			Client.Credentials = credentials;
			Client.EnableSsl = true;
			Client.DeliveryMethod = SmtpDeliveryMethod.Network;
			Client.Send(msg);
		}
	}
}