using System;
using PagedList;
using System.Text;
using System.Linq;
using Absa.DTO;
using System.Web.Mvc;
using Absa.Web.Models;
using Absa.DateAccess;
using System.Security.Cryptography;
using System.Collections.Generic;


namespace Absa.Web.Controllers
{
	public class AccountController : Controller
    {
		AbsaDBEntities context = new AbsaDBEntities();
	
		public ActionResult Login()
		{
			return View();
		}
 
		public ActionResult RecoverPassword()
		{
			return View();
		}

		public ActionResult UserList(int? page)
		{
			var id = this.Session["ID"];
			int userId = Convert.ToInt32(id);
			var rolesPermission = context.Users.FirstOrDefault(x=>x.UserID == userId);
			var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
			string rolePermissionType = Convert.ToString(permissions.Type);
			ViewBag.RolePermission = rolePermissionType;

			var model = new List<UserDTO>();
			try
			{
				if (rolePermissionType == "Manager") {
					var data = context.GetAllUsersList();
					foreach (var item in data)
					{
						model.Add(new UserDTO()
						{
							ID = item.UserID,
							FirstName = item.FirstName,
							LastName = item.LastName,
							EmailAddress = item.EmailAddress,
							ContactNumber = item.ContactNumber,
							RolesPermission = item.Type,
							BusinessUnit = item.BusinessUnitName,
							IsActive = Convert.ToBoolean(item.IsActive)
						});
					}
				}
				else {
					var data = context.GetUserById(userId);
					foreach (var item in data)
					{
						model.Add(new UserDTO()
						{
							ID = item.UserID,
							FirstName = item.FirstName,
							LastName = item.LastName,
							EmailAddress = item.EmailAddress,
							ContactNumber = item.ContactNumber,
							RolesPermission = item.Type,
							BusinessUnit = item.BusinessUnitName,
							IsActive = Convert.ToBoolean(item.IsActive)
						});
					}
				}
				
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}
			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return this.View("UserList", model.ToPagedList(pageNumber, pageSize));
		}
		

		public ActionResult CreateUser()
		{
			UserDTO model = new UserDTO();
			model.BusinestUnitList = context.BusinessUnits.OrderBy(x => x.BusinessUnitName).Select(x => new SelectListItem
			{
				Value = x.BusinessUnitId.ToString(),
				Text = x.BusinessUnitName
			});

			model.RolesPermissionList = context.RolesPermissions.OrderBy(x => x.Type).Select(x => new SelectListItem
			{
				Value = x.RolesPermissionsID.ToString(),
				Text = x.Type
			});
			return PartialView(model);
		}

		public ActionResult EditUser(string userId)
		{
			var model = new UserDTO();
			string number = System.Text.RegularExpressions.Regex.Replace(userId, @"\D+", string.Empty);
			int id = Convert.ToInt16(number);
			var items = context.DataLookUps.Where(x => x.LoopkUpID == 1).ToList();
			if (items != null)
			{
				ViewBag.data = items;
			}
			if (id != 0)
			{
				try
				{
					var data = context.Users.Where(m => m.UserID == id);
					foreach (var result in data)
					{
						model.ID = result.UserID;
						model.FirstName = result.FirstName;
						model.LastName = result.LastName;
						model.EmailAddress = result.EmailAddress;
						model.ContactNumber = result.ContactNumber;
						model.UserName = result.UserName;
						model.IsActive = Convert.ToBoolean(result.IsActive);
						model.RolesPermission = Convert.ToString(result.RolesPermissionsID);
						model.BusinessUnit = Convert.ToString(result.BusinessUnitId);
					}
				}
				catch (Exception ex)
				{
					var error = ex.Message;
				}
				model.BusinestUnitList = context.BusinessUnits.OrderBy(x => x.BusinessUnitName).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				});

				model.RolesPermissionList = context.RolesPermissions.OrderBy(x => x.Type).Select(x => new SelectListItem
				{
					Value = x.RolesPermissionsID.ToString(),
					Text = x.Type
				});
			}
			return PartialView(model);
		}

		public ActionResult AddUpdateUser(UserDTO model)
		{
			
			DTO.Extentions.Password _paswword = new DTO.Extentions.Password();
			var userPassword  = _paswword.RandomPassword();
			
			var userName = model.FirstName + model.LastName;

			if (model.ID == 0)
			{
				var data = context.Users.FirstOrDefault(u => u.EmailAddress == model.EmailAddress && u.ContactNumber == model.ContactNumber);
				if (data != null){
					ViewBag.ErroMessage = "Email provided already exist " + data.EmailAddress + " .";
				}
				else{
					context.AddUser(model.FirstName, model.LastName, model.EmailAddress, userName, model.ContactNumber, model.IsActive
									, int.Parse(model.RolesPermission), int.Parse(model.BusinessUnit), Convert.ToString(userPassword));
					var userEmailNotification = new DTO.Extentions.Email();
					userEmailNotification.CreateUserAccountNotificationEmail(model.EmailAddress, userName, password);
					return RedirectToAction("UserList", "Account");
				}
			}
			else
			{
				var _data = context.UpdateUser(model.ID, model.FirstName, model.LastName, model.EmailAddress, userName,
										   model.ContactNumber, model.IsActive, int.Parse(model.RolesPermission), int.Parse(model.BusinessUnit), password);
				var userEmailNotification = new DTO.Extentions.Email();
				userEmailNotification.UpdateUserDetailsNotificationEmail(model.EmailAddress, userName, password);
				return RedirectToAction("UserList", "Account");
			}
			return RedirectToAction("UserList", "Account");
		}

		public ActionResult DeleteUser(string userId)
		{
			var id = Convert.ToInt32(userId);
			var model = new List<UserDTO>();
			try {
				var data = context.Users.Where(x=>x.UserID == id);
				foreach (var item in data)
				{
					model.Add(new UserDTO()
					{
						ID = item.UserID,
						FirstName = item.FirstName,
						LastName = item.LastName,
					});
				}
			} catch (Exception ex)
			{
				throw ex;
			}
			return View(model);
		}

		[HttpPost]
		public ActionResult Delete(string userId)
		{
			
			if (userId != null)
			{
				int id = Convert.ToInt32(userId);
				var data = context.Users.Find(id);
				context.Users.Remove(data);
				context.SaveChanges();
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public ActionResult GetUserAccess(UserDTO model)
		{
			if (model.Password != null && model.UserName != null)
			{
				MD5 md5Hash = MD5.Create();
				string input = model.Password;
				var password = GetMd5Hash(md5Hash, input);

				if (model.UserName != null)
				{
					var data = context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password.Equals(password));
					if (data != null)
					{
						if (data.IsActive == false)
						{
							ViewBag.ErroMessage = "Your acccount is not active please ask your line manager to activate your account";
						}
						else
						{
							this.Session["ID"] = data.UserID;
							this.Session["UserName"] = data.UserName;
							this.Session["FirstName"] = data.FirstName;
							this.Session["LastName"] = data.LastName;
							ViewBag.Details = this.Session["FirstName"] + " " + this.Session["LastName"];
							return RedirectToAction("Index", "Home");
						}
					}
					else
					{
						ViewBag.ErroMessage = "Incorrect login detail provided.";
					}
				}
			}
			ViewBag.ErroMessage = "Incorrect username and password.";
			return View("Login");
		}

		private static readonly Encoding Encoding1252 = Encoding.GetEncoding(1252);
		public static byte[] SHA1HashValue(string s)
		{
			byte[] bytes = Encoding1252.GetBytes(s);

			var sha1 = SHA512.Create();
			byte[] hashBytes = sha1.ComputeHash(bytes);

			return hashBytes;
		}

		static string GetMd5Hash(MD5 md5Hash, string input)
		{
		
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}
		
	}
}