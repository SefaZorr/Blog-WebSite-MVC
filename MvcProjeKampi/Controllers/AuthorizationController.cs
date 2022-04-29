using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            ViewBag.roles = GetRoles();
            var adminValue = adm.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public List<SelectListItem> GetRoles()
        {
            List<string> roles = new List<string>();
            roles.Add("A");
            roles.Add("B");
            roles.Add("C");
            List<SelectListItem> adminRole = (from x in roles
                                              select new SelectListItem
                                              {
                                                  Text = x,
                                                  Value = x
                                              }).ToList();
            return adminRole;
        }

        public ActionResult StatusChangedAdmin(int id)
        {
            var admin = adm.GetByID(id);
            if (admin.AdminStatus)
            {
                admin.AdminStatus = false;
            }
            else
            {
                admin.AdminStatus = true;
            }
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}