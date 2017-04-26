using BusinessPermit.Models;
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
        private static string GetPaymentUrl()
        {
            Uri requestUri = HttpContext.Current.Request.Url;
            string baseUrl = requestUri.Scheme + Uri.SchemeDelimiter + requestUri.Host + (requestUri.IsDefaultPort ? "" : ":" + requestUri.Port) + "//Payment//Create";
            return baseUrl;
        }

        public static string BusinessPermitApprovedTemplate(BusinessPermit.Models.BusinessPermit permit, List<Fee> fees)
        {
            //  Thank you for using the service. Have a nice day!
            string result = String.Format(@"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Business Permit</b> has been <b>APPROVED</b>.
                      
                       <br/>    
                       <br/>
                       Your Reference Number for the permits payment is <b>{0}</b>
                       <br/>
                       <br/>
                       The following are your fees for this application:
                       <br/>
                       <br/>", permit.PaymentReference);
            float total = 0;

            foreach (var item in fees)
            {
                total += item.Price;
                result += string.Format("P{0}&nbsp;&nbsp;&nbsp;- {1} <br/><br/>", item.Price, item.Description);
            }

            result += "P" + total + " - <b>TOTAL</b> <br/><br/> ";

            result += String.Format("For us to verify your payment, kindly click this <a href=\"{0}\">link</a> upon settling your account. <br/><br/>", GetPaymentUrl());
            result += " </div><br/><br/><br/><br/> Thank you for using the service. Have a nice day!";

            return result;
        }
        public static string BusinessPermitDeniedTemplate()
        {
            return @"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Business Permit</b> has been <b>DENIED</b>.
                       </div>
                      <br/>    
                       <br/>
                       Please see office personnel for further inquiries.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static string BusinessPermitCertifyTemplate()
        {
            return @"<br>       
                         Congratulations!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                          In the attached file is your electronic Business Permit certified by the City of Marikina.
                       </div>
                      <br/>    
                       <br/>
                       If you have any inquiries, feel free to see our personnel.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static string BuildingPermitApprovedTemplate(BuildingPermit permit, List<Fee> fees)
        {
            string result = String.Format(@"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Building Permit</b> has been <b>APPROVED</b>.
                      
                       <br/>    
                       <br/>
                       Your Reference Number for the permits payment is <b>{0}</b>
                       <br/>
                       <br/>
                       The following are your fees for this application:
                       <br/>
                       <br/>", permit.PaymentReference);
            float total = 0;

            foreach (var item in fees)
            {
                total += item.Price;
                result += string.Format("P{0}&nbsp;&nbsp;&nbsp;- {1} <br/><br/>", item.Price, item.Description);
            }

            result += "P" + total + " - <b>TOTAL</b> <br/><br/> ";

            result += String.Format("For us to verify your payment, kindly click this <a href=\"{0}\">link</a> upon settling your account. <br/><br/>", GetPaymentUrl());
            result += " </div><br/><br/><br/><br/> Thank you for using the service. Have a nice day!";

            return result;
        }

        public static string BuildingPermitDeniedTemplate()
        {
            return @"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Building Permit</b> has been <b>DENIED</b>.
                       </div>
                       <br/>    
                       <br/>
                       Please see office personnel for further inquiries.
                       <br/>
                       <br/>                      
                       Thank you for using the service. Have a nice day!";
        }

        public static string BuildingPermitCertifyTemplate()
        {
            return @"<br>       
                         Congratulations!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                          In the attached file is your electronic Building Permit certified by the City of Marikina.
                       </div>
                      <br/>    
                       <br/>
                       If you have any inquiries, feel free to see our personnel.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static string ZoningClearanceApprovedTemplate(ZoningClearance permit, List<Fee> fees)
        {
            string result = String.Format(@"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Zoning Clearance</b> has been <b>APPROVED</b>.
                      
                       <br/>    
                       <br/>
                       Your Reference Number for the permits payment is <b>{0}</b>
                       <br/>
                       <br/>
                       The following are your fees for this application:
                       <br/>
                       <br/>", permit.PaymentReference);
            float total = 0;

            foreach (var item in fees)
            {
                total += item.Price;
                result += string.Format("P{0}&nbsp;&nbsp;&nbsp;- {1} <br/><br/>", item.Price, item.Description);
            }

            result += "P" + total + " - <b>TOTAL</b> <br/><br/> ";

            result += String.Format("For us to verify your payment, kindly click this <a href=\"{0}\">link</a> upon settling your account. <br/><br/>", GetPaymentUrl());
            result += " </div><br/><br/><br/><br/> Thank you for using the service. Have a nice day!";

            return result;
        }

        public static string ZoningClearanceDeniedTemplate()
        {
            return @"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Zoning Clearance</b> has been <b>DENIED</b>.
                       </div>
                       <br/>    
                       <br/>
                       Please see office personnel for further inquiries.
                       <br/>
                       <br/>
                       Thank you for using the service. Have a nice day!";
        }

        public static string ZoningClearanceCertifyTemplate()
        {
            return @"<br>       
                         Congratulations!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                          In the attached file is your electronic Zoning Clearance certified by the City of Marikina.
                       </div>
                      <br/>    
                       <br/>
                       If you have any inquiries, feel free to see our personnel.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static string LocationalClearanceApprovedTemplate(LocationalClearance permit, List<Fee> fees)
        {
            string result = String.Format(@"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Locational Clearance</b> has been <b>APPROVED</b>.
                      
                       <br/>    
                       <br/>
                       Your Reference Number for the permits payment is <b>{0}</b>
                       <br/>
                       <br/>
                       The following are your fees for this application:
                       <br/>
                       <br/>", permit.PaymentReference);
            float total = 0;

            foreach (var item in fees)
            {
                total += item.Price;
                result += string.Format("P{0}&nbsp;&nbsp;&nbsp;- {1} <br/><br/>", item.Price, item.Description);
            }

            result += "P" + total + " - <b>TOTAL</b> <br/><br/> ";

            result += String.Format("For us to verify your payment, kindly click this <a href=\"{0}\">link</a> upon settling your account. <br/><br/>", GetPaymentUrl());
            result += " </div><br/><br/><br/><br/> Thank you for using the service. Have a nice day!";

            return result;
        }

        public static string LocationalClearanceDeniedTemplate()
        {
            return @"<br>       
                         Good Day!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                           This is to inform you that your application for <b>Locational Clearance</b> has been <b>APPROVED</b>.
                       </div>
                       <br/>    
                       <br/>
                       Please see office personnel for further inquiries.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static string LocationalClearanceCertifyTemplate()
        {
            return @"<br>       
                         Congratulations!
                       <br/>
                       <br/>
                       <br/>
                       <br/>
                       <div style=""margin-left:30px;"">
                          In the attached file is your electronic Locational Clearance certified by the City of Marikina.
                       </div>
                      <br/>    
                       <br/>
                       If you have any inquiries, feel free to see our personnel.
                       <br/>
                       <br/>   
                       Thank you for using the service. Have a nice day!";
        }

        public static void SendMail(string receipients, string subject, string body, Attachment attachment = null)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("marikina.application@gmail.com", "typewriter14344");
            client.EnableSsl = true;
            MailMessage mail = new MailMessage("marikina.application@gmail.com", receipients, subject, body);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Low;

            if (attachment != null)
            {
                mail.Attachments.Add(attachment);
            }          

            client.Send(mail);
        }

        public static Attachment CreateAttachment()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);
            writer.Write("Hello its my sample file");
            writer.Flush();
            writer.Dispose();

            System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            Attachment attach = new Attachment(ms, ct);
            attach.ContentDisposition.FileName = "myFile.pdf";


            return attach;
            // I guess you know how to send email with an attachment
            // after sending email
          

            
        }
    }
}