using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var message = string.Format("Comment from: {1}{0} Email: {2}{0}WebSite: {3}{0}Comment{4}",
                                        Environment.NewLine,
                                        model.Name,
                                        model.Email,
                                        model.Website,
                                        model.Comment);
            if (_mailService.SendMail("noreply@domain.com", "foo@domain.com", "Website Contact", message))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }
    }
}
