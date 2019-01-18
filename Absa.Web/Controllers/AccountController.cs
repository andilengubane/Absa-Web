using System;
using PagedList;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using PagedList.Mvc;
using Absa.Web.Models;
using System.Net.Mail;
using System.Diagnostics;
using Absa.DateAccess;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
			// GET USER RolePermission Type 
			var rolesPermission = context.Users.FirstOrDefault(x=>x.UserID == userId);
			var permissions = context.RolesPermissions.FirstOrDefault(x => x.RolesPermissionsID == rolesPermission.RolesPermissionsID);
			string rolePermissionType = Convert.ToString(permissions.Type);
			ViewBag.RolePermission = rolePermissionType;

			var model = new List<UserModel>();
			try
			{
				if (rolePermissionType == "Manager") {
					var data = context.GetAllUsersList();
					foreach (var item in data)
					{
						model.Add(new UserModel()
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
						model.Add(new UserModel()
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

		public ActionResult Register()
		{
			
			var model = new UserModel()
			{
				BusinestUnitList = context.BusinessUnits.OrderBy(x=>x.BusinessUnitName).Select(x => new SelectListItem
				{
					Value = x.BusinessUnitId.ToString(),
					Text = x.BusinessUnitName
				})
			};
			return View(model);
		}

		public ActionResult CreateUser()
		{
			UserModel model = new UserModel();
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
			var model = new UserModel();
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
						//model.Password = result.Password;
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

		public ActionResult AddUpdateUser(UserModel model)
		{
			var numberOfChars = 8;
			var upperCase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			var lowerCase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			var specialCharacters = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
			var random = new Random();

			var total = upperCase.Concat(lowerCase).Concat(numbers).Concat(specialCharacters).ToArray();

			var chars = Enumerable.Repeat<int>(0, numberOfChars).Select(i => total[random.Next(total.Length)]).ToArray();

			var password = new string(chars);
			var data = context.Users.FirstOrDefault(u => u.EmailAddress == model.EmailAddress && u.ContactNumber == model.ContactNumber);
			if (data != null)
			{
				ViewBag.ErroMessage = "Email provided already exist " + data.EmailAddress + " .";
			}
			else
			{
				if (model.ID == 0)
				{
					context.AddUser(model.FirstName, model.LastName, model.EmailAddress, model.UserName, model.ContactNumber, model.IsActive
									, int.Parse(model.RolesPermission), int.Parse(model.BusinessUnit), password);
				}
				ViewBag.ErrorMessage = "Your account is not active yet please see your line Manager or Supervisor to activate your account";
			}
			
			var _data = context.UpdateUser(model.ID, model.FirstName, model.LastName, model.EmailAddress, model.UserName,
				                           model.ContactNumber, model.IsActive, int.Parse(model.RolesPermission), int.Parse(model.BusinessUnit), password);
			return RedirectToAction("UserList", "Account");
		}

		public ActionResult DeleteUser(string userId)
		{
			var id = Convert.ToInt32(userId);
			var model = new List<UserModel>();
			try {
				var data = context.Users.Where(x=>x.UserID == id);
				foreach (var item in data)
				{
					model.Add(new UserModel()
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
		public ActionResult GetUserAccess(UserModel model)
		{
			var s = Encrypt(model.Password);
			byte[] _data = Convert.FromBase64String(s);

			if (model.UserName != null)
			{
				var data = context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == _data);
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
			ViewBag.ErroMessage = "Incorrect username and password.";
			return View("Login");
		}


		private string Encrypt(string clearText)
		{
			string EncryptionKey = "SHA2_512";
			byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cs.Write(clearBytes, 0, clearBytes.Length);
						cs.Close();
					}
					clearText = Convert.ToBase64String(ms.ToArray());
				}
			}
			return clearText;
		}
	}
}