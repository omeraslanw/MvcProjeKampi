using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        public ActionResult MyContent(string sessionValue)
        {
            sessionValue = (string)Session["WriterMail"];
            var writerIDInfo = context.Writers.Where(x => x.WriterMail == sessionValue).Select(y => y.WriterID).FirstOrDefault();
            var myContents = contentManager.GetListByWriter(writerIDInfo);
            return View(myContents);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string sessionValue = (string)Session["WriterMail"];
            var writerIDInfo = context.Writers.Where(x => x.WriterMail == sessionValue).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIDInfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}