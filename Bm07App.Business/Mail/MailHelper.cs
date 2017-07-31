using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;

public class MailHelper
{
    public async Task<bool> sendAsync(string from, string toUser, string subject, string message)
    {
        //set smtp credentials
        var smtpPort = 587;
        var smtpHost = "";
        var login = "";
        var password = "";

        try
        {
            using (var mail = new MailMessage())
            {
                var fromMail = new MailAddress(from, from);
                var toMailUser = new MailAddress(toUser);

                //set message
                mail.From = fromMail;
                mail.To.Add(toMailUser);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = message;

                //create client
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = smtpHost;
                    smtp.Port = smtpPort;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Credentials = new System.Net.NetworkCredential(login, password);
                    smtp.UseDefaultCredentials = false;

                    await smtp.SendMailAsync(mail);
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}