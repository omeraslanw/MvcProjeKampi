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
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headdingList = headingManager.GetList();
            return View(headdingList);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListById(id);
            return PartialView(contentList);
        }
    }
}