using System;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace JAPhotography.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
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
            //var images = db.DbImages.Select(s => new
            //{
            //    s.thumbnail,
            //    s.image,
            //    s.width,
            //    s.height
            //});

            //List<ImageViewModel> getImages = images.Select(item => new ImageViewModel()
            //{
            //    thumbnail = item.image,
            //    image = item.image,
            //    width = item.width,
            //    height = item.height
            //}).ToList();

            //return PartialView(getImages);

            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return PartialView();
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
                NetworkCredential cred = new NetworkCredential("jennaabbottphotography@hotmail.com", "Autob0ts");
                MailMessage msg = new MailMessage();
                MailAddress from = new MailAddress("jennaabbottphotography@hotmail.com");

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = true;

                msg.From = from;
                msg.To.Add("jennaabbottphotography@hotmail.com");
                msg.Subject = "Jenna Abbott Photography: " + subject;
                msg.IsBodyHtml = true;

                StringBuilder sb = new StringBuilder();
                sb.Append("<b>Name:</b> " + name + "<br />");
                sb.Append("<b>Email Address:</b> " + email + "<br />");
                sb.Append("<b>Message:</b> " + message);
                msg.Body = sb.ToString();

                smtp.Send(msg);
                msg.Dispose();

                return PartialView("~/Views/Home/_ContactSuccess.cshtml");
            }
            catch (Exception)
            {
                return PartialView("~/Views/Home/_Error.cshtml");
            }
        }

        public ActionResult _Popup()
        {
            return PartialView();
        }

        //public ActionResult _PopupImage(string imageUrl)
        //{

        //}
    }
}