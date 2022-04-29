using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using MvcProjeKampi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService _authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        AdminManager adm = new AdminManager(new EfAdminDal());
        
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminForLoginDto adminForLoginDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LeHwZEfAAAAAJHb8yS4SDkIRQgWs1iXUxLBdGLC";
            var client = new WebClient();
            var reply =
                    client.DownloadString(
                        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (captchaResponse.Success)
            {
                var userToLogin = _authService.AdminLogin(adminForLoginDto);
                var user = adm.GetByMail(adminForLoginDto.Email);

                if (!userToLogin)
                {
                    TempData["Message"] = "Kullanıcı Adınız veya Şifreniz Hatalı Lütfen Tekrar Deneyiniz";
                    return RedirectToAction("Index");

                }
                else if (user.AdminStatus == false)
                {
                    TempData["Message"] = "Pasif Kullanıcı Ile Giriş Yapamazsınız";
                    return RedirectToAction("Index");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(adminForLoginDto.Email, false);
                    Session["AdminMail"] = adminForLoginDto.Email;
                    var session = Session["AdminMail"];
                    ViewBag.a = session;
                    return RedirectToAction("Index", "Heading");
                }
            }
            else
            {
                TempData["Message"] = "Lütfen Güvenliği Doğrulayınız";
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(WriterForLoginDto writerForLoginDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LeHwZEfAAAAAJHb8yS4SDkIRQgWs1iXUxLBdGLC";
            var client = new WebClient();
            var reply =
                    client.DownloadString(
                        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (captchaResponse.Success)
            {
                var userToLogin = _authService.WriterLogin(writerForLoginDto);
                if (!userToLogin)
                {
                    TempData["Message"] = "Kullanıcı Adınız veya Şifreniz Hatalı Lütfen Tekrar Deneyiniz";
                    return RedirectToAction("WriterLogin");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(writerForLoginDto.Email, false);
                    Session["WriterMail"] = writerForLoginDto.Email;
                    var session = Session["WriterMail"];
                    ViewBag.a = session;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
            }
            else
            {
                TempData["Message"] = "Lütfen Güvenliği Doğrulayınız";
                return RedirectToAction("WriterLogin");

            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}