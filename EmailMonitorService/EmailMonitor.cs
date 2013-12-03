using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailMonitorService
{
    class EmailMonitor
    {
        private EmailClient _emailClient;
        private PrimaryEntities _dbContext;

        public EmailMonitor()
        {
            _emailClient = new EmailClient();
            _dbContext = new PrimaryEntities();
        }

        public int SendUnprocessedEmails()
        {
            int emailsSent = 0;

            try
            {
                _dbContext.EmailRecords.Where(email => email.IsSent == false)
                                   .ToList()
                                   .ForEach(message =>
                                   {
                                       _emailClient.SendMail(message.EmailSubject, message.Source, message.Body);
                                       message.SentDate = DateTime.Now;
                                       message.IsSent = true;
                                       emailsSent++;
                                   }
                                   );

                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                //issue with _dbcontext
                throw e;
            }

            return emailsSent;
        }

        //public static void OnSendCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //    e.
        //}
                   
}
}
