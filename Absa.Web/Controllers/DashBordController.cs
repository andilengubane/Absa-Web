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
		// GET: DashBord
		public ActionResult Report()
		{
			return PartialView();
		}
		public ActionResult StrategicFit()
		{
			return PartialView();
		}

		public ActionResult GetStrategicFitData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var strategicFitappData = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in strategicFitappData)
			{
				model.StrategicFitYes = Convert.ToInt32(item.StrategicFitYes);
				model.StrategicFitNo = Convert.ToInt32(item.StrategicFitNo);
				model.StrategicFitWarning = Convert.ToInt32(item.StrategicFitWarning);
				model.ApplicationPatchingLevelNo = Convert.ToInt32(item.StrategicFitOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}


		public ActionResult GetDisasterRecoverData()
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new DashBordModel();

			var disasterRecover = context.GetAppStatus(data.BusinessUnitId);
			foreach (var item in disasterRecover)
			{
				model.DisasterRecoveryYes = Convert.ToInt32(item.DisasterRecoverYes);
				model.DisasterRecoveryNo = Convert.ToInt32(item.DisasterRecoverNo);
				model.DisasterRecoveryWarning = Convert.ToInt32(item.DisasterRecoverWarning);
				model.DisasterRecoverOverRall = Convert.ToInt32(item.DisasterRecoverOverRall);
			}
			return Json(model, JsonRequestBehavior.AllowGet);
		}
	}
}