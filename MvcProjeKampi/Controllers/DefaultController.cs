using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal()); 
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList().Where(x => x.HeadingStatus == true).ToList();
            return View(headingList);
        }
        public PartialViewResult Index(int id = 1)
        {
            var contentList = cm.GetListByHeadingID(id);
            ViewBag.Id = id;
            return PartialView(contentList);
        }
    }
}