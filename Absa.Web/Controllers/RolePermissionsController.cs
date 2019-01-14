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

		public ActionResult RolePermission(string rolePermissionID)
		{
			var _Id = this.Session["ID"];
			int userId = Convert.ToInt32(_Id);
			var dataStatus = context.Users.FirstOrDefault(u => u.UserID == userId);

			string number = System.Text.RegularExpressions.Regex.Replace(rolePermissionID, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);

			var model = new RolePermissionsModel();
			if (model.RolesPermissionsID == 0)
			{
				return PartialView();
			}
			else
			{
				try
				{
					var data = context.RolesPermissions.Where(m => m.RolesPermissionsID == model.RolesPermissionsID);
					foreach (var result in data)
					{
						model.RolesPermissionsID = result.RolesPermissionsID;
						model.Type = result.Type;
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
		public ActionResult SaveUpdateRolePermission( RolePermissionsModel model)
		{
			if (model.RolesPermissionsID == 0)
			{
				var id = this.Session["ID"];
				int userId = Convert.ToInt32(id);
				var datas = context.Users.FirstOrDefault(u => u.UserID == userId);
			
				var rolesPermission = context.Users.FirstOrDefault(x => x.UserID == userId);
				var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
				string rolePermissionType = Convert.ToString(permissions.Type);

				context.RolesPermissions.Add(new RolesPermission
				{
					Type = model.Type,
					UserId = userId,
					DateLogged = DateTime.Now,
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

				var data = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == model.RolesPermissionsID);
				data.Type = model.Type;
				data.UserId = userId;
				data.Description = model.Description;
			}
			context.SaveChanges();
			return RedirectToAction("UserList", "Home");
		}
    }
}