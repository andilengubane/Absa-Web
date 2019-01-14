using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.Web.Models;

namespace Absa.Web.Controllers
{
    public class BusinessUnitController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
        // GET: BusinessUnit
        public ActionResult Index()
        {
			var model = new BusinessUnitModel();
			var data = context.BusinessUnits.ToList();
			foreach (var item in data)
			{
				model.BusinessUnitId = item.BusinessUnitId;
				model.BusinessUnitName = item.BusinessUnitName;
				model.Description = item.Description;
				model.IsActive = item.IsActive.Value;
				model.NumberOfApps = item.NumberOfApps.Value;
				model.DateLogged = item.DateLogged.Value;

			}
			List<BusinessUnitModel> viewModelList = new List<BusinessUnitModel>();
			viewModelList.Add(model);
			return PartialView(viewModelList.AsEnumerable());
        }
    }
}