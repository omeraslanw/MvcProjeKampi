using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager loginManager = new LoginManager(new EfLoginDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterLoginDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //Context context = new Context();
            //var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            var adminInfo = loginManager.LoginAdmin(admin.AdminUserName, admin.AdminPassword);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName, false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCatogory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writerInfo = writerLoginManager.LoginWriter(writer.WriterMail, writer.WriterPassword);
            if (writerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        [HttpGet]
        public ActionResult RegisterWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterWriter(Writer writer)
        {
            var writerInfo = writerLoginManager.LoginWriter(writer.WriterMail, writer.WriterPassword);
            if (writerInfo != null)
            {
                writerManager.WriterAdd(writer);
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("RegisterWriter");
            }
        }
    }
}