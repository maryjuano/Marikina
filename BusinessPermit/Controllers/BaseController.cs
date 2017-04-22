using BusinessPermit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPermit.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        

        protected int CurrentUserId
        {
            get
            {
                if (Request.Cookies["App"] != null)
                {
                   return Convert.ToInt32(Request.Cookies["App"]["userId"]);
                }
                return 0;
            }
        }

        protected string CurrentUserFullName
        {
            get {
                if (Request.Cookies["App"] != null)
                {
                   return Request.Cookies["App"]["fullName"];
                }
                return string.Empty;
            }
            
        }
        protected void SetUserCookie(Users data)
        {
            HttpCookie userCookieCredentials = new HttpCookie("App");
            userCookieCredentials["userId"] = data.UserId.ToString();
            userCookieCredentials["fullName"] = data.FullName;
            userCookieCredentials.Expires.AddMinutes(60);
            Response.Cookies.Add(userCookieCredentials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected byte[] GetFileBytes(HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {              
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();             
            }
            return data;
        }
    }
}