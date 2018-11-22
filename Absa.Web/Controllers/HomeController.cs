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
		AbsaDataModelEntities context = new AbsaDataModelEntities();
		public ActionResult Index()
		{
			var model = new DashBord()
			{
				StatusList = context.Departments.Select(x => new SelectListItem
				{
					Value = x.DepartmentID.ToString(),
					Text = x.DepartmentName
				})
			};
			return View(model);
		}
		public ActionResult Approval()
		{
			return View();
		}
	}
}