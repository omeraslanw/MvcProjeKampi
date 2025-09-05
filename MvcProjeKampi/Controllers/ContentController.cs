using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string content = "")
        {
            var contentValues = contentManager.GetList(content);
            return View(contentValues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListById(id);
            return View(contentValues);
        }
    }
}