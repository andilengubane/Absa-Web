﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Absa.Web.Models;
using System.Net.Mail;
using System.Diagnostics;
using Absa.DateAccess;
using System.Collections.Generic;

namespace Absa.Web.Controllers
{
    public class AccountController : Controller
    {
		AbsaDataModelEntities context = new AbsaDataModelEntities();
		// GET: Account
		public ActionResult Login()
		{
			return View();
		}

		// GET: Recover Password 
		public ActionResult RecoverPassword()
		{
			return View();
		}

		public ActionResult UserList()
		{
			var model = new List<UserModel>();
			try
			{
				var data = from dashBordList in context.Users
						   select dashBordList;
				foreach (var item in data)
				{
					model.Add(new UserModel()
					{
						ID = item.UserID,
						FirstName = item.FirstName,
						LastName = item.LastName,
						EmailAddress = item.EmailAddress,
						UserName = item.UserName,
						ContactNumber = item.ContactNumber,
						IsActive = Convert.ToBoolean(item.IsActive)
	              });
				}
			}
			catch (Exception ex)
			{
				string error = ex.Message;
			}
			return this.View("UserList", model);
		}

		// GET: Register
		public ActionResult Register()
		{
			
			var model = new UserModel()
			{
				BusinestUnitList = context.Departments.Select(x => new SelectListItem
				{
					Value = x.DepartmentID.ToString(),
					Text = x.DepartmentName
				})
			};
			return View(model);
		}

		public ActionResult CreateUser()
		{
			UserModel model = new UserModel();
			model.BusinestUnitList = context.Departments.Select(x => new SelectListItem
			{
				Value = x.DepartmentID.ToString(),
				Text = x.DepartmentName
			});

			model.RolesPermissionList = context.RolesPermissions.Select(x => new SelectListItem
			{
				Value = x.RolesPermissionsID.ToString(),
				Text = x.Type
			});
			return PartialView(model);
		}

		public ActionResult EditUser(string userID)
		{
			var model = new UserModel();
			int id = Convert.ToInt16(userID);
			var items = context.DataLookUps.Where(x => x.LookUpNameID == 1).ToList();
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
					}
				}
				catch (Exception ex)
				{
					var error = ex.Message;
				}
				model.BusinestUnitList = context.Departments.Select(x => new SelectListItem
				{
					Value = x.DepartmentID.ToString(),
					Text = x.DepartmentName
				});

				model.RolesPermissionList = context.RolesPermissions.Select(x => new SelectListItem
				{
					Value = x.RolesPermissionsID.ToString(),
					Text = x.Type
				});
			}
			return PartialView(model);
		}

		// POST: Account
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
						ViewBag.ErroMessage = "Your account is not active please ask your line manager to activate your account";
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
					ViewBag.ErroMessage = "Your logged in details are incorrect.";
				}
			}
			return View("Login");
		}

		// POST: Register New User 
		public ActionResult AddNewUser(UserModel model)
		{
			if (ModelState.IsValid)
			{
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
						DepartmentID = Convert.ToInt32(model.BusinessUnit),
						IsActive = true
					});
					context.SaveChanges();
					/*
					 
				     MailMessage msg = new MailMessage();
				     msg.From = new MailAddress("joe@contoso.com");
				     msg.To.Add(new MailAddress(model.EmailAddress));
				     msg.Subject = "User Request Access";
				     msg.Body = " Please see Activate the user account " + model.FirstName +" "+ model.LastName + ".";
				     
				     SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
				     System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("joe@contoso.com", "XXXXXX");
				     smtpClient.Credentials = credentials;
				     smtpClient.EnableSsl = true;
				     smtpClient.Send(msg);

				   */
					ViewBag.ErrorMessage = "Your account is not active yet please see your line Manager or Supervisor to activate your account";
					return this.RedirectToAction("Login", "Account");
				}
			}
			
			var models = new UserModel()
			{
				BusinestUnitList = context.Departments.Select(x => new SelectListItem
				{
					Value = x.DepartmentID.ToString(),
					Text = x.DepartmentName
				})
			};
			return this.View("Register", models);
		}

		// POST: Recover Password 
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