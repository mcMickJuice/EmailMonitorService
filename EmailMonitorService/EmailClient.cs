using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.Security;

namespace EmailMonitorService
{
    class EmailClient
    {
        private SmtpClient _smtpClient;
        string smtpHost = ConfigurationManager.AppSettings["SmtpServer"];
        string senderAddress = ConfigurationManager.AppSettings["SenderAddress"];
        string senderPassword = ConfigurationManager.AppSettings["SenderPassword"];
        string recipientAddress = ConfigurationManager.AppSettings["RecipientAddress"];

        public EmailClient()
        {
            _smtpClient = new SmtpClient(smtpHost)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderAddress, senderPassword),
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 10000
            };

           // _smtpClient.SendCompleted += onSendHandler;
        }

        public void SendMail(string subject, string source, string body)
        {
            using (var mail = new MailMessage(senderAddress, recipientAddress, subject + "-" + source, body))
            {
                mail.BodyEncoding = UTF8Encoding.UTF8;
                _smtpClient.Send(mail);
            }
            
        }
    }
}
