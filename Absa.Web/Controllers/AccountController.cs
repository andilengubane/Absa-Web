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
						model.Password = result.Password;
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
			if (model.ID == 0)
			{
				context.Users.Add(new User
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					EmailAddress = model.EmailAddress,
					ContactNumber = model.ContactNumber,
					UserName = model.UserName,
					Password = model.Password,
					Datelogged = DateTime.Now,
					IsActive = model.IsActive,
					BusinessUnitId = int.Parse(model.BusinessUnit),
					RolesPermissionsID = int.Parse(model.RolesPermission)
				});
			}
			else
			{
				var data = context.Users.FirstOrDefault(x => x.UserID == model.ID);
				data.UserID = model.ID;
				data.FirstName = model.FirstName;
				data.LastName = model.LastName;
				data.EmailAddress = model.EmailAddress;
				data.ContactNumber = model.ContactNumber;
				data.UserName = model.UserName;
				data.Password = model.Password;
				data.Datelogged = DateTime.Now;
				data.IsActive = model.IsActive;
				data.BusinessUnitId = int.Parse(model.BusinessUnit);
				data.RolesPermissionsID = int.Parse(model.RolesPermission);
			}
			context.SaveChanges();
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
			if (model.UserName != null)
			{
				var data = context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
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
 
		public ActionResult AddNewUser(UserModel model)
		{
			if (ModelState.IsValid)
			{
				//return this.RedirectToAction("Index", "DashBord");
				var data = context.Users.FirstOrDefault(u => u.EmailAddress == model.EmailAddress && u.ContactNumber == model.ContactNumber);
				if (data != null)
				{
					ViewBag.ErroMessage = "Email provided already exist " + data.EmailAddress + " .";
				}
				else
				{
					context.Users.Add(new User
					{
						UserName = model.UserName,
						Password = model.Password,
						LastName = model.LastName,
						FirstName = model.FirstName,
						EmailAddress = model.EmailAddress,
						Datelogged = DateTime.Now,
						ContactNumber = model.ContactNumber,
						BusinessUnitId = Convert.ToInt32(model.BusinessUnit),
						IsActive = false
					});
					context.SaveChanges();
					/*
				    TODO: Send email to supervisor or line manager
				   */
					ViewBag.ErrorMessage = "Your account is not active yet please see your line Manager or Supervisor to activate your account";
					return this.RedirectToAction("Login", "Account");
				}
			}
			var models = new UserModel();
			model.BusinestUnitList = context.BusinessUnits.OrderBy(x => x.BusinessUnitName).Select(x => new SelectListItem
			{
				Value = x.BusinessUnitId.ToString(),
				Text = x.BusinessUnitName
			});

			return this.View("Register", models);
		}
		
		public ActionResult ForgotPassword(UserModel model)
		{
			if (model.EmailAddress != null)
			{
				try
				{
					var result = from user in context.Users
								 where user.EmailAddress == model.EmailAddress
								 select user;
					foreach (var item in result)
					{
						var password = item.Password;
						var emailAddress = item.EmailAddress;
						MailMessage msg = new MailMessage();
						msg.From = new MailAddress("joe@contoso.com");
						msg.To.Add(new MailAddress(emailAddress));
						msg.Subject = "Recover Password";
						msg.Body = " Please make sure you don't you keep your password" + password;

						SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
						System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("joe@contoso.com", "XXXXXX");
						smtpClient.Credentials = credentials;
						smtpClient.EnableSsl = true;
						smtpClient.Send(msg);
					}
				}
				catch (Exception ex)
				{
					string error = ex.Message;
				}
				ViewBag.ErrorMessage = "Please check your email Address";
				return this.View("Login");
			}
			return this.View("RecoverPassword", model);
		}
	}
}