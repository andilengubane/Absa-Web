using System;
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

		// GET: Register
		public ActionResult Register()
		{
			
			var model = new UserModel()
			{
				StatusList = context.Departments.Select(x => new SelectListItem
				{
					Value = x.DepartmentID.ToString(),
					Text = x.DepartmentName
				})
			};
			return View(model);
		}

		// POST: Account
		[HttpPost]
		public ActionResult GetUserAccess(UserModel model)
		{
			if (model.UserName != null)
			{
				// check if the user IsActive
				var data = context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
				if (data != null)
				{
					if (data.IsActive == false)
					{
					  ViewBag.ErroMessage = "Your acccount is not active please ask your line manager to activate your account";
					}
					else {
						this.Session["ID"] = data.UserID;
						this.Session["UserName"] = data.UserName;
						this.Session["FirstName"] = data.FirstName;
						this.Session["LastName"] = data.LastName;
						ViewBag.Details = this.Session["FirstName"] + " " + this.Session["LastName"];
						return RedirectToAction("Index", "Orders");
					}
				}
				else
				{
					ViewBag.ErroMessage = "Incorrect login detail provided.";
				}
			}
			return View("Login");
		}

		// POST: Register New User 
		public ActionResult AddNewUser(UserModel model)
		{
			if (ModelState.IsValid)
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
					DepartmentID = Convert.ToInt32(model.Department),
					IsActive = false
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
				ViewBag.ErrorMessage = "Your account is not active please see your Manager or Superviser to Activate You account";
				return this.RedirectToAction("Index", "DashBord");
			}

			var models = new UserModel()
			{
				StatusList = context.Departments.Select(x => new SelectListItem
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
						var emailAddres = item.EmailAddress;
						this.sendMail(password, emailAddres);
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

		public void sendMail(string password, string emailAddress)
		{
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
}