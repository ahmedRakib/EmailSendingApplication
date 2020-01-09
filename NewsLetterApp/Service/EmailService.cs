using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NewsLetterApp.Models;

namespace NewsLetterApp.Service
{
    public class EmailService : IEmailService
    {
        string smtpServer;
        string from;
        string port;
        string senderEmail;
        string senderPassword;

        public EmailService(IConfiguration configuration)
        {
            smtpServer = configuration.GetSection("EmailSettings").GetSection("MailServer").Value;
            port = configuration.GetSection("EmailSettings").GetSection("MailPort").Value;
            from = configuration.GetSection("EmailSettings").GetSection("SenderName").Value;
            senderEmail = configuration.GetSection("EmailSettings").GetSection("Sender").Value;
            senderPassword = configuration.GetSection("EmailSettings").GetSection("Password").Value;
        }

    

         

        public void SendEmail(EmailInfo emailInfo)
        {
            //MailMessage mail = new MailMessage();

            try
            {
                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient(smtpServer);

                mail.From = new MailAddress(from);

                mail.To.Add(emailInfo.To);

                mail.Subject = emailInfo.Subject;

                mail.Body = emailInfo.Body;

                mail.IsBodyHtml = true;

                SmtpServer.Port = Convert.ToInt32(port);

                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                SmtpServer.UseDefaultCredentials = false;

                SmtpServer.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

                SmtpServer.EnableSsl = true;



                SmtpServer.Send(mail);

              
            }
            catch ( Exception ex)
            {

                throw ex;
            }

            

           
        }
    }
}
