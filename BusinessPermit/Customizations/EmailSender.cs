using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BusinessPermit
{
    public static class EmailSender
    {
        public static void SendMail(string receipients, string subject, string body)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("marikina.application@gmail.com", "typewriter14344"),
                EnableSsl = true
            };

            client.Send("marikina.application@gmail.com", receipients, subject, body);           
        }
    }
}