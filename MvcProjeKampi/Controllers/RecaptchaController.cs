using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft;

namespace MvcProjeKampi.Controllers
{
    public class RecaptchaController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string title)
        {
            // If we are here, Captcha is validated.  
            return View();
        }
    }
}