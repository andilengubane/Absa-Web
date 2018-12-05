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
			var model = new DashBord()
			{
				BusinessUnitList = context.BusinessUnits.OrderBy(x => x.BusinessUnitName).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitName.ToString(),
					Text = x.BusinessUnitName
				})
			};
			return View(model);
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
		public ActionResult Approval(string id)
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
			return View();
		}
	}
}