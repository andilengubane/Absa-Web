﻿using System;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Collections.Generic;


namespace Absa.Web.Models
{
	public class Email
	{
		public void SendEmail(string email, string body, string businessUnit, string applicationID, string requestedBy, string applicationDeclined)
		{

			MailMessage msg = new MailMessage();
			msg.From = new MailAddress("mthembungubane@gmail.com");
			msg.To.Add(new MailAddress(email));
			msg.Subject = "Request Declined";
			msg.Body = "Business Unit" + businessUnit +
					   "\n Application Id" + applicationID +
					   "\n Approval Requested By" + requestedBy +
					   "\n Application Declined" + applicationDeclined +
					   "\n " + body + "\n <img src=cid:sImage /></body></html></body></html>" +
					   "\n <img src=cid:sImage /></body></html></body></html>";
			SmtpClient Client = new SmtpClient("smtp.gmail.com");
			Client.Port = 587;
			Client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mthembungubane@gmail.com", "andile1234!@#$");
			Client.Credentials = credentials;
			Client.EnableSsl = true;
			Client.DeliveryMethod = SmtpDeliveryMethod.Network;
			Client.Send(msg);
		}

		public void CreateUserAccountNotificationEmail(string email, string userName, string password)
		{
			MailMessage msg = new MailMessage();
			msg.From = new MailAddress("mthembungubane@gmail.com");
			msg.To.Add(new MailAddress(email));
			msg.Subject = "T100R Login Details";
			msg.Body = "\n New Account Details" +
					   "\n Username : " + userName +
					   "\n Password : " + password +
					   "\n Your account is not active yet please see your line Manager or Supervisor to activate your account"; 
			SmtpClient Client = new SmtpClient("smtp.gmail.com");
			Client.Port = 587;
			Client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mthembungubane@gmail.com", "andile1234!@#$");
			Client.Credentials = credentials;
			Client.EnableSsl = true;
			Client.DeliveryMethod = SmtpDeliveryMethod.Network;
			Client.Send(msg);
		}

		public void UpdateUserDetailsNotificationEmail(string email, string userName, string password)
		{
			MailMessage msg = new MailMessage();
			msg.From = new MailAddress("mthembungubane@gmail.com");
			msg.To.Add(new MailAddress(email));
			msg.Subject = "T100R Login Details";
			msg.Body = "\n Account Updated SuccessFul " + 
					   "\n Username : " + userName +
					   "\n Password : " + password +
					   "\n Note account details has been changed. Please keep your password !!!";
			SmtpClient Client = new SmtpClient("smtp.gmail.com");
			Client.Port = 587;
			Client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mthembungubane@gmail.com", "andile1234!@#$");
			Client.Credentials = credentials;
			Client.EnableSsl = true;
			Client.DeliveryMethod = SmtpDeliveryMethod.Network;
			Client.Send(msg);
		}
	}
}