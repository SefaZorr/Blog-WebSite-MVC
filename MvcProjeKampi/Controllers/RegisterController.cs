using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService _authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminForRegisterDto adminForRegisterDto)
        {
            _authService.AdminRegister(adminForRegisterDto, adminForRegisterDto.Password);
            return RedirectToAction("Index", "Heading");
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(WriterForRegisterDto writerForRegisterDto)
        {
            _authService.WriterRegister(writerForRegisterDto, writerForRegisterDto.Password);
            return RedirectToAction("Index", "Heading");
        }
    }
}