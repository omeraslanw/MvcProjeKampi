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
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult UpdateAbout(int id)
        {
            var aboutValue = aboutManager.GetByID(id);
            switch (aboutValue.AboutStatus)
            {
                case true:
                    aboutValue.AboutStatus = false;
                    break;
                case false:
                    aboutValue.AboutStatus = true;
                    break;

            }
            aboutManager.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
    }
}