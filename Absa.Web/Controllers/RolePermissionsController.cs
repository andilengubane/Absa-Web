using System;
using System.Web;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using Absa.DateAccess;
using Absa.Web.Models;
using System.Collections.Generic;

namespace Absa.Web.Controllers
{
    public class RolePermissionsController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
        // GET: RolePermissions
        public ActionResult Index(int? page)
        {
			var model = new List<RolePermissionsModel>();
			var data = context.RolesPermissions.ToList();
			foreach (var item in data)
			{
				model.Add(new RolePermissionsModel
				{
			       RolesPermissionsID = item.RolesPermissionsID,
				   Type = item.Type,
				   DateLogged = item.DateLogged.Value,
				   Description = item.Description,
			    });

			}
			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return this.PartialView("Index", model.ToPagedList(pageNumber, pageSize));
		}

		public ActionResult RolePermission(string rolePermissionsId)
		{
			var _Id = this.Session["ID"];
			int userId = Convert.ToInt32(_Id);
			var dataStatus = context.Users.FirstOrDefault(u => u.UserID == userId);
			int id = 0;
			if (rolePermissionsId != "")
			{
				string number = System.Text.RegularExpressions.Regex.Replace(rolePermissionsId, @"\D+", string.Empty);
				id = Convert.ToInt16(number);
			}
		

			var model = new RolePermissionsModel();
			if (id == 0)
			{
				return PartialView();
			}
			else
			{
				try
				{
					var data = context.RolesPermissions.Where(m => m.RolesPermissionsID == id);
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
			return RedirectToAction("UserList", "Account");
		}
    }
}