using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.Web.Models;
namespace Absa.Web.Controllers
{
    public class ReportController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
		// GET: Report
		public ActionResult Report()
        {
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			var model = new ReportModel()
			{
				BusinessUnitList = context.BusinessUnits.Where(x => x.BusinessUnitId == data.BusinessUnitId).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				})
			};

			model.BusinessUnitId = Convert.ToInt32(data.BusinessUnitId);
			return View("Report",model);
        }

		[HttpPost]
		public ActionResult RejectedReport(ReportModel model)
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var data = context.Users.FirstOrDefault(u => u.UserID == userId);
			model.BusinessUnitList = context.BusinessUnits.Where(x => x.BusinessUnitId == data.BusinessUnitId).Select(x => new SelectListItem
			{
				Value = x.BusinessUnitId.ToString(),
				Text = x.BusinessUnitName
			});

			//model.BusinessUnitId = Convert.ToInt32(data.BusinessUnitId);
			//model.ShowReport = true;
			//model.ReportName = model.ReportName;
			//ViewBag.FromDate = model.FromDate;
			//ViewBag.tomDate = model.ToDate;
			//ViewBag.SelectedStatus = model.SelectedStatusCode;
			return this.View("Report", model);
		}
	}
}