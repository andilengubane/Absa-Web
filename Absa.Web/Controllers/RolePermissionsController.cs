using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.Web.Models;

namespace Absa.Web.Controllers
{
    public class RolePermissionsController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
        // GET: RolePermissions
        public ActionResult Index()
        {
			var model = new RolePermissionsModel();
			var data = context.RolesPermissions.ToList();
			foreach (var item in data)
			{
				model.RolesPermissionsID = item.RolesPermissionsID;
				model.Type = item.Type;
				model.DateLogged = item.DateLogged.Value;
				model.Description = item.Description;
			}
			List<RolePermissionsModel> viewModelList = new List<RolePermissionsModel>();
			viewModelList.Add(model);
			return PartialView(viewModelList.AsEnumerable());
        }
    }
}