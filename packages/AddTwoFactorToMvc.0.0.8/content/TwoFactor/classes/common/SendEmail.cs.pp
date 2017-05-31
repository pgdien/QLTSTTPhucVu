using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using OtpSharp;
using Base32;
using System.Net.Mail;

namespace $rootnamespace$
{
    public class Emailer
    {
        public void sendEmail(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage("donotreply@yourcompany.com", email,subject, body);
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();

            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "localhost";

            client.Send(mail);
        }
    }
}