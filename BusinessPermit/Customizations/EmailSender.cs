using BusinessPermit.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Hosting;

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


        public static Attachment CreateAttachment(BuildingPermit building)
        {
            Document doc = new Document(new Rectangle(PageSize.A4));
            //Create PDF Table
            PdfPTable tableLayout = new PdfPTable(4);
            string fileName = string.Format("BuildingPermit-{0}-{1}.pdf", building.ApplicationNumber, DateTime.Now.ToShortDateString().Replace("/", ""));
            string path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", fileName));
            FileStream fm = new FileStream(path, FileMode.Create);
            //Create a PDF file in specific path
            PdfWriter.GetInstance(doc, fm);

            //Open the PDF document
            doc.Open();

            Paragraph para = new Paragraph(@"BUILDING PERMIT",
                new Font(Font.FontFamily.TIMES_ROMAN, 24f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para.Alignment = Element.ALIGN_CENTER;
            doc.Add(para);
            string scopeOfWork = building.ScopeOfWork.GetEnumDescription();
            string use = building.BuildingUse.GetEnumDescription();

            if (building.ScopeOfWork == 0)
            {
                scopeOfWork = building.ScopeOfWorkOther;
            }
            if (building.BuildingUse == 0)
            {
                use = building.BuildingUseOther;
            }
            

            string value = String.Format(@"Permit is issued to {0} {1} for the proposed {2} under {3}, of Group {4}, located at Lot No.{5}Block No.{6}OCT//TCT No. {7}, {8} Street, Barangay {9}, City//Municipality of {10} subject to the following: ",
                                        building.FirstName, building.LastName, scopeOfWork, building.OccupancyClassified, building.LocationLotNumber, building.LocationBlockNumber, building.LocationTCTNumber, building.LocationStreet, building.LocationStreet, building.LocationBarangay, building.LocationCity);

            Paragraph para1 = new Paragraph(value,
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para.Alignment = Element.ALIGN_CENTER;
            doc.Add(para1);


            Paragraph para2 = new Paragraph("1. That under Article 1723 of the Civil Code of the Philippines, the engineer or architect who drew up the plans and specifications for a building/structure is liable for damages if within fifteen (15) years from the completion of the building/structure, the same should collapse due to defect intheplans or specifications or defects in the ground. The engineer or architect who supervises the construction shall be solidarily liable with the contractor should the edifice collapse due to defect in the construction or the use of inferior materials.",
               new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para2.FirstLineIndent = 10;
            para2.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para2);

            Paragraph para3 = new Paragraph("2. This permit shall be accompanied by the various applicable ancillary and accessory permits, plans and specifications signed and sealed by the corresponding design professionals who shall be responsible for the comprehensive and correctness of the plansin compliance to the Code and its IRR and to all applicable referral codes and professional regulatory laws. ",
               new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para3.FirstLineIndent = 10;
            para3.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para3);

            Paragraph para4 = new Paragraph("3. That no building/structure shall be used until the Building Official has issued a Certificate of Occupancy therefor as provided in the Code. However, a partial Certificate of Occupancy may be issued for the Use/Occupancy of a portion or portions of a building/structure prior to the completion of the entire building/structure. ",
             new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para4.FirstLineIndent = 10;
            para4.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para3);

            Paragraph para5 = new Paragraph("4.  That this permit shall not serve as an exemption from securing written clearances from various government authorities exercising regulatory function affecting buildings/structures. ",
         new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para5.FirstLineIndent = 10;
            para5.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para5);

            Paragraph para6 = new Paragraph("5.   When the construction is undertaken by contract, the work shall be done by a duly licensed and registered contractor pursuant to the provisions of the Contractor’s License Law (RA 4566).",
        new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para6.FirstLineIndent = 10;
            para6.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para6);

            Paragraph para7 = new Paragraph("6.    The Owner/Permittee shall submit a duly accomplished prescribed “Notice of Construction” to the Office of the Building Official prior to any construction activity.",
        new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para7.FirstLineIndent = 10;
            para7.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para7);

            Paragraph para8 = new Paragraph("7.     The Owner/Permittee shall put a Building Permit sign which complies with the prescribed dimensions and information, which shall remain posted on the construction site for the duration of the construction.",
    new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para8.FirstLineIndent = 10;
            para8.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para8);

            Image sign = Image.GetInstance(HttpContext.Current.Server.MapPath(string.Format("~/Images/Tomas.png")));
            sign.Alignment = Element.ALIGN_RIGHT;
            sign.ScaleToFit(140f, 120f);
            sign.IndentationRight = 55;
            sign.SpacingBefore = 15;

            doc.Add(sign);

            Paragraph para12 = new Paragraph("Tomas C. Aguilar, Jr.",
new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para12.IndentationRight = 55;
            para12.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para12);

            Paragraph para13 = new Paragraph("Locational Administrator/City Planning and Development Officer",
new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para13.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para13);

           
              Paragraph para14 = new Paragraph(" NOTE :  THIS PERMIT MAY BE CANCELLED OR REVOKED PURSUANT TO SECTIONS 305 AND 306 OF THE “NATIONAL BUILDING CODE”",
new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
              para14.SpacingBefore = 25;
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
              para14.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
              doc.Add(para14);


            doc.Close();

            ContentType ct = new ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            Attachment attachment = new Attachment(path);
            attachment.ContentDisposition.FileName = fileName + ".pdf";

            return attachment;      
        }

        public static Attachment CreateAttachment(BusinessPermit.Models.BusinessPermit building)
        {
            Document doc = new Document(new Rectangle(PageSize.A4));
            //Create PDF Table
            PdfPTable tableLayout = new PdfPTable(4);
            string fileName = string.Format("BusinessPermit-{0}-{1}.pdf", building.BusinessAccountNumber, DateTime.Now.ToShortDateString().Replace("/", ""));
            string path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", fileName));
            FileStream fm = new FileStream(path, FileMode.Create);
            //Create a PDF file in specific path
            PdfWriter.GetInstance(doc, fm);

            //Open the PDF document
            doc.Open();

            Paragraph para = new Paragraph(@"BUSINESS PERMIT AND LICENSE OFFICE",
                new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para.Alignment = Element.ALIGN_CENTER;
            doc.Add(para);

            Paragraph para1 = new Paragraph(@"BUSINESS PERMIT",
             new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para1.Alignment = Element.ALIGN_CENTER;
            doc.Add(para1);


            Paragraph para9 = new Paragraph("THIS IS TO CERTIFY THAT.",
 new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para9.SpacingBefore = 30;
            para9.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para9);

            Paragraph para8 = new Paragraph(building.BusinessName,
    new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.UNDERLINE, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para8.SpacingBefore = 5;
            para8.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para8);

            Paragraph para10 = new Paragraph(@"(Business Trade Name)",
 new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class       
            para10.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para10);

            Paragraph para11 = new Paragraph(building.OwnerName,
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.UNDERLINE, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class       
            para11.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para11);

            Paragraph para14 = new Paragraph(@"(Business Owner's Name)",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class       
            para14.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para14);

            Paragraph para15 = new Paragraph(building.BusinessAddress,
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.UNDERLINE, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class       
            para15.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para15);

            Paragraph para16 = new Paragraph(@"(Business Address)",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class       
            para16.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para16);

            Paragraph para7 = new Paragraph(@"is hereby granted this permit nad license to operate and/or establish his/her business in the city subject to the provisions of the City Revenue Code of Marikina and other ordinances/laws/regulations pertinent thereto.",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class  
            para7.SpacingBefore = 10;
            para7.Alignment = Element.ALIGN_JUSTIFIED_ALL;
            // Adding this 'para' to the Document object
            doc.Add(para7);


            Image sign = Image.GetInstance(HttpContext.Current.Server.MapPath(string.Format("~/Images/Other.png")));
            sign.SpacingBefore = 40;
            sign.Alignment = Element.ALIGN_LEFT;
            sign.ScaleToFit(140f, 120f);
           

            doc.Add(sign);


            Paragraph para12 = new Paragraph("Atty. Nancy V. Taylan                                                                  Marcelino Teodoro",
     new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class 
            para12.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para12);

            Paragraph para13 = new Paragraph("Locational Administrator/Business Permit Licensing Office                             Honorable City Mayor",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para13.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para13);


            Paragraph para17 = new Paragraph("ERASURES OR ALTERATIONS WILL INVALIDATE THIS PERMIT",
  new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class           
            para17.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para17);

            Paragraph para18 = new Paragraph(@"this PERMIT should be conspicuously at the place when the business before is/are being conducted and shall be presented and/or surrendered to concerened authorities upon demand. This permit is revocable and is null and void if t he permittee violates any applicable law ordinance and/or regulation or if he fails to pay any tax and fee charges as they become due.",
new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class 
            para18.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para18);

            Paragraph para19 = new Paragraph(@"In case of business closer/retirment, please surrender this permit to the office of BPLO twenty (20) days after said closure to avoid penalty.",
new Font(Font.FontFamily.TIMES_ROMAN, 10f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class 
            para19.Alignment = Element.ALIGN_CENTER;
            // Adding this 'para' to the Document object
            doc.Add(para19);

            // Closing the document
            doc.Close();

            ContentType ct = new ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            Attachment attachment = new Attachment(path);
            attachment.ContentDisposition.FileName = fileName + ".pdf";

            return attachment;
        }
        
        public static Attachment CreateAttachment(LocationalClearance locational)
        {          
            Document doc = new Document(new Rectangle(PageSize.A4));
            //Create PDF Table
            PdfPTable tableLayout = new PdfPTable(4);
            string fileName = string.Format("Locational-{0}-{1}.pdf", locational.ApplicationNumber, DateTime.Now.ToShortDateString().Replace("/", ""));
            string path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", fileName));
            FileStream fm = new FileStream(path, FileMode.Create);
            //Create a PDF file in specific path
            PdfWriter.GetInstance(doc, fm);
         
            //Open the PDF document
            doc.Open();
            
            Paragraph para = new Paragraph(@"Republic of the Philippines",
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para.Alignment = Element.ALIGN_CENTER;
            doc.Add(para);

            Paragraph para1 = new Paragraph("City of Marikina",
           new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para1.Alignment = Element.ALIGN_CENTER;
            doc.Add(para1);

             Paragraph para2 = new Paragraph("City Planning and Development Office",
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
             para2.Alignment = Element.ALIGN_CENTER;
            doc.Add(para2);
       

            //Add Content to PDF           
            Paragraph para3 = new Paragraph("LOCATIONAL CLEARANCE is hereby GRANTED TO " + locational.Project + " which is conforming as to Land Use Classification of the site per Zoning Ordinance No. 161, series of 2006 subject to the following conditions: ",
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para3.SpacingBefore = 25;
            para3.SpacingAfter = 15;
            para3.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para3);


            Paragraph para4 = new Paragraph("1.	That this clearance shall be posted in a conspicuous place within the premises/building during construction/operation.",
               new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para4.FirstLineIndent = 10;
            para4.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para4);

            Paragraph para5 = new Paragraph("2.	That the proponent cannot undertake any activity other than the project applied for without the approval of this office.",
              new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para5.FirstLineIndent = 10;
            para5.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para5);

            Paragraph para6 = new Paragraph("3.	That any material falsehood or misrepresentation of the documents submitted made in connection with the said application shall render the clearance null and void from the beginning.",
           new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para6.FirstLineIndent = 10;
            para6.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para6);

            Paragraph para7 = new Paragraph("4.	That the implementation of the proposal should commence within a period of one year from the date of issuance of this clearance otherwise the proponent should re-apply for a new location clearance.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para7.FirstLineIndent = 10;
            para7.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para7);

            Paragraph para8 = new Paragraph("5.	That this office reserves the rights to inspect and review said project/operation and subsequently institute cancellation proceedings should the same be found in violation in any of the herein conditions and other pertinent government policies, rules and regulations.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para8.FirstLineIndent = 10;
            para8.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para8);

            Paragraph para9 = new Paragraph("6.	That this clearance shall not, in any way, be interpreted to vest any title, right of ownership, or the right of possession of the land herein.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para9.FirstLineIndent = 10;
            para9.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para9);

            Paragraph para10 = new Paragraph("7. That no additional structure/expansion shall be done without the approval of this office.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para10.FirstLineIndent = 10;
            para10.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para10);


            Paragraph para11 = new Paragraph("8. The other provisions set forth in the National Building Code (P.D. 1096) relative to this activity shall be complied with.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para11.FirstLineIndent = 10;
            para11.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para11);

            Image sign = Image.GetInstance(HttpContext.Current.Server.MapPath(string.Format("~/Images/Tomas.png")));
            sign.Alignment = Element.ALIGN_RIGHT;
            sign.ScaleToFit(140f, 120f);
            sign.IndentationRight = 55;
            sign.SpacingBefore = 15;

            doc.Add(sign);


            Paragraph para12 = new Paragraph("Tomas C. Aguilar, Jr.",
  new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para12.IndentationRight = 55;         
            para12.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para12);

            Paragraph para13 = new Paragraph("Locational Administrator/City Planning and Development Officer",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para13.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para13);

            // Closing the document
            doc.Close();

            ContentType ct = new ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            Attachment attachment = new Attachment(path);
            attachment.ContentDisposition.FileName = fileName + ".pdf";

            return attachment;      
        }


        public static Attachment CreateAttachment(ZoningClearance zoning)
        {
            Document doc = new Document(new Rectangle(PageSize.A4));
            //Create PDF Table
            PdfPTable tableLayout = new PdfPTable(4);
            string fileName = string.Format("ZoningClearance-{0}-{1}.pdf", zoning.ApplicationNumber, DateTime.Now.ToShortDateString().Replace("/", ""));
            string path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", fileName));
            FileStream fm = new FileStream(path, FileMode.Create);
            //Create a PDF file in specific path
            PdfWriter.GetInstance(doc, fm);

            //Open the PDF document
            doc.Open();

            Paragraph para = new Paragraph(@"Republic of the Philippines",
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para.Alignment = Element.ALIGN_CENTER;
            doc.Add(para);

            Paragraph para1 = new Paragraph("City of Marikina",
           new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para1.Alignment = Element.ALIGN_CENTER;
            doc.Add(para1);

            Paragraph para2 = new Paragraph("Business Permit Licensing Office",
               new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para2.Alignment = Element.ALIGN_CENTER;
            doc.Add(para2);


            //Add Content to PDF           
            Paragraph para3 = new Paragraph("ZONING CLEARANCE is hereby GRANTED TO " + zoning.OwnerName + " which is conforming as to Land Use Classification of the site per Zoning Ordinance No. 161, series of 2006 subject to the following conditions: ",
                new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class
            para3.SpacingBefore = 25;
            para3.SpacingAfter = 15;
            para3.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para3);


            Paragraph para4 = new Paragraph("1.	That this clearance shall be posted in a conspicuous place within the premises/business during construction/operation.",
               new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para4.FirstLineIndent = 10;
            para4.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para4);


            Paragraph para6 = new Paragraph("2.	That any material falsehood or misrepresentation of the documents submitted made in connection with the said application shall render the clearance null and void from the beginning.",
           new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para6.FirstLineIndent = 10;
            para6.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para6);

            Paragraph para7 = new Paragraph("3.	That the implementation of the proposal should commence within a period of one year from the date of issuance of this clearance otherwise the proponent should re-apply for a new location clearance.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para7.FirstLineIndent = 10;
            para7.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para7);

            Paragraph para8 = new Paragraph("4.	That this office reserves the rights to inspect and review said project/operation and subsequently institute cancellation proceedings should the same be found in violation in any of the herein conditions and other pertinent government policies, rules and regulations.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para8.FirstLineIndent = 10;
            para8.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para8);

            Paragraph para9 = new Paragraph("5.	That this clearance shall not, in any way, be interpreted to vest any title, right of ownership, or the right of possession of the land herein.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para9.FirstLineIndent = 10;
            para9.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para9);

            Paragraph para10 = new Paragraph("6. That no additional business shall be done without the approval of this office.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para10.FirstLineIndent = 10;
            para10.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para10);


            Paragraph para11 = new Paragraph("7. The other provisions set forth in the Business Code (P.D. 1096) relative to this activity shall be complied with.",
      new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para11.FirstLineIndent = 10;
            para11.Alignment = Element.ALIGN_LEFT;
            // Adding this 'para' to the Document object
            doc.Add(para11);

            Image sign = Image.GetInstance(HttpContext.Current.Server.MapPath(string.Format("~/Images/Other.png")));
            sign.Alignment = Element.ALIGN_RIGHT;
            sign.ScaleToFit(140f, 120f);
            sign.IndentationRight = 35;
            sign.SpacingBefore = 15;

            doc.Add(sign);


            Paragraph para12 = new Paragraph("Atty. Nancy V. Taylan",
  new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para12.IndentationRight = 35;
            para12.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para12);

            Paragraph para13 = new Paragraph("Locational Administrator/Business Permit Licensing Office",
new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL, BaseColor.BLACK));
            // Setting paragraph's text alignment using iTextSharp.text.Element class        
            para13.Alignment = Element.ALIGN_RIGHT;
            // Adding this 'para' to the Document object
            doc.Add(para13);

            // Closing the document
            doc.Close();

            ContentType ct = new ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
            Attachment attachment = new Attachment(path);
            attachment.ContentDisposition.FileName = fileName + ".pdf";

            return attachment;
        }




   }
}