using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JAPhotography.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace JAPhotography.Controllers
{
    public class HomeController : Controller
    {
        // Get images from directories to place them on the website.
        public DirImagesModel GetImages()
        {
            DirImagesModel dim = new DirImagesModel()
            {
                Thumbnails = Directory.EnumerateFiles(Server.MapPath("~/Content/images/thumbs")).Select(fn => "~/content/images/thumbs/" + Path.GetFileName(fn)).ToList(),
                Images = Directory.EnumerateFiles(Server.MapPath("~/Content/images/gallery")).Select(fn => "~/Content/images/gallery/" + Path.GetFileName(fn)).ToList()
            };

            return dim;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Error()
        {
            return PartialView();
        }

        public ActionResult _Landing()
        {
            //"/Views/Home/_Landing.cshtml"
            // Add model to gallery

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView();
            //}
            //else
            //{
            //    return View();
            //}

            return PartialView();
        }

        public ActionResult _Gallery()
        {
            return PartialView(GetImages());
        }

        public ActionResult _About()
        {
            return PartialView();
        }

        public ActionResult _Investment()
        {
            return PartialView();
        }

        public ActionResult _Contact()
        {
            return PartialView();
        }

        public ActionResult _ContactSend(string email, string name, string subject, string message)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
                NetworkCredential cred = new NetworkCredential("zacdibble@hotmail.com", "12R59aT10m0430ja");
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress("zacdibble@hotmail.com");

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = true;

                msg.From = from;
                msg.To.Add("zacdibble@hotmail.com");
                msg.Subject = "Jenna Abbott Photography: " + subject;
                msg.IsBodyHtml = true;

                StringBuilder sb = new StringBuilder();
                sb.Append("<b>Name:</b> " + name + "<br />");
                sb.Append("<b>Email Address:</b> " + email + "<br />");
                sb.Append("<b>Message:</b> " + message);
                msg.Body = sb.ToString();

                //smtp.Send(msg);
                msg.Dispose();

                return PartialView("_ContactSuccess.cshtml");
                //return PartialView();
            }
            catch (Exception)
            {
                return PartialView("_Error");
            }
        }

        public ActionResult _04302010()
        {
            return View();
        }
    }
}