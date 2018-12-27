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

			var strategicFitAppData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitAppData)
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

			var strategicFitAppData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitAppData)
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

			var strategicFitAppData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitAppData)
			{
				model.BackUpConfigurationYes = Convert.ToInt32(item.BackUpConfigurationYes);
				model.BackUpConfigurationNo = Convert.ToInt32(item.BackUpConfigurationNo);
				model.BackUpConfigurationWarning = Convert.ToInt32(item.BackUpConfigurationWarning);
				model.BackUpConfigurationOverRall = Convert.ToInt32(item.BackUpConfigurationOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
		
	}
}