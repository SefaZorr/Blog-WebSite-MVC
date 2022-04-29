using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["AdminMail"];
            var result = cm.GetList().Count();
            ViewBag.contactMailCount = result;
            var sendMail = mm.GetListSendBox(p).Count();
            ViewBag.sendMailCount = sendMail;
            var inMail = mm.GetListInbox(p).Count();
            ViewBag.inboxMailCount = inMail;
            return PartialView();
        }
    }
}