using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace EmailMonitorService
{
    class EmailClient
    {
        private SmtpClient _smtpClient;

        public EmailClient()
        {
            string smtpHost = ConfigurationManager.AppSettings["SmtpServer"];
            string senderAddress = ConfigurationManager.AppSettings["SenderAddress"];
            string senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

            _smtpClient = new SmtpClient(smtpHost)
            {
                Credentials = new NetworkCredential(senderAddress, senderPassword),
                EnableSsl = true,
                Port = 465
            };
        }

        public void SendMail(string from, string recipient, string subject, string body)
        {
            _smtpClient.Send(from, recipient,subject,body);
            //_smtpClient.
        }
    }
}
