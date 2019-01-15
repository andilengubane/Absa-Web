using System;
using PagedList;
using System.Web;
using System.Linq;
using PagedList.Mvc;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.Web.Models;
using System.Collections.Generic;

namespace Absa.Web.Controllers
{
    public class BusinessUnitController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
        
        public ActionResult Index(int? page)
        {
			var model = new List<BusinessUnitModel>();
			var data = context.BusinessUnits.ToList();
			foreach (var item in data)
			{
				model.Add(new BusinessUnitModel()
				{
				 BusinessUnitId = item.BusinessUnitId,
				 BusinessUnitName = item.BusinessUnitName,
				 Description = item.Description,
				 IsActive = item.IsActive.Value,
				 NumberOfApps = item.NumberOfApps.Value,
				 DateLogged = item.DateLogged.Value
			    });
			}
			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return this.PartialView("Index", model.ToPagedList(pageNumber, pageSize));
        }
		public ActionResult BusinessUnit(string businessUnitId)
		{
			var _Id = this.Session["ID"];
			int userId = Convert.ToInt32(_Id);
			var dataStatus = context.Users.FirstOrDefault(u => u.UserID == userId);
			int id = 0;
			if (businessUnitId != "") {
				string number = System.Text.RegularExpressions.Regex.Replace(businessUnitId, @"\D+", string.Empty);
				id = Convert.ToInt16(number);
			}

			var model = new BusinessUnitModel();
			if (id == 0)
			{
				return PartialView();
			}
			else
			{
				try
				{
					var data = context.BusinessUnits.Where(m => m.BusinessUnitId == id);
					foreach (var result in data)
					{
						model.BusinessUnitId = result.BusinessUnitId;
						model.BusinessUnitName = result.BusinessUnitName;
						model.NumberOfApps = result.NumberOfApps.Value;
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
					NumberOfApps = model.NumberOfApps,

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
				data.NumberOfApps = model.NumberOfApps;
				data.UserId = userId;
				data.IsActive = model.IsActive;
				data.Description = model.Description;
			}
			context.SaveChanges();
			return RedirectToAction("UserList", "Account");
		}
	}
}