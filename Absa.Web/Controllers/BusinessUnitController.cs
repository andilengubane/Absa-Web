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
		public ActionResult BusinessUnit(string businessUnit)
		{
			var _Id = this.Session["ID"];
			int userId = Convert.ToInt32(_Id);
			var dataStatus = context.Users.FirstOrDefault(u => u.UserID == userId);

			string number = System.Text.RegularExpressions.Regex.Replace(businessUnit, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);

			var model = new BusinessUnitModel();
			if (model.BusinessUnitId == 0)
			{
				return PartialView();
			}
			else
			{
				try
				{
					var data = context.BusinessUnits.Where(m => m.BusinessUnitId == model.BusinessUnitId);
					foreach (var result in data)
					{
						model.BusinessUnitId = result.BusinessUnitId;
						model.BusinessUnitName = result.BusinessUnitName;
						model.IsActive = result.IsActive.Value;
						model.DateLogged = result.DateLogged.Value;
						model.Description = result.Description;
					}
				}
				catch (Exception ex)
				{
					var error = ex.Message;
				}
			}
			return PartialView(model);
		}
		public ActionResult SaveUpdateBusinessUnit(BusinessUnitModel model)
		{
			if (model.BusinessUnitId == 0)
			{
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);
				var datas = context.Users.FirstOrDefault(u => u.UserID == userId);

				var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
				var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permissions.Type);

				context.BusinessUnits.Add(new BusinessUnit
				{
					BusinessUnitName = model.BusinessUnitName,
					UserId = userId,
					DateLogged = DateTime.Now,
					IsActive = model.IsActive,
					Description = model.Description,

				});
			}
			else
			{
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);

				var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
				var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permissions.Type);

				var data = context.BusinessUnits.FirstOrDefault(x => x.BusinessUnitId == model.BusinessUnitId);
				data.BusinessUnitName = model.BusinessUnitName;
				data.UserId = userId;
				data.IsActive = model.IsActive;
				data.Description = model.Description;
			}
			context.SaveChanges();
			return RedirectToAction("UserList", "Home");
		}
	}
}