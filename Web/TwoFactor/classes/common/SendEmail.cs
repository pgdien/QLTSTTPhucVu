using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using OtpSharp;
using Base32;
using System.Net.Mail;

namespace Web
{
    public class Emailer
    {
        public void sendEmail(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(email));
            mail.From = new MailAddress("ketnoitre.jsc@gmail.com");
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("ketnoitre.jsc@gmail.com", "Huydaika123@");// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}