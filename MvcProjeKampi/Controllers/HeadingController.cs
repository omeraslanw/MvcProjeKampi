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
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var heading = headingManager.GetList();
            return View(heading);
        }

        public ActionResult HeadingByWriter(int id)
        {
            var headingValues = headingManager.GetByID(id);
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,//burası display member olarak geçer, yani arayüzde gösterilecek kısımdır
                                                      Value = x.CategoryID.ToString()//burası value member olarak geçer, yani arka planda bu kısmın id değerini tutar
                                                  }).ToList();
            List<SelectListItem> writerValue = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.category = categoryValue;
            ViewBag.writer = writerValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,//burası display member olarak geçer, yani arayüzde gösterilecek kısımdır
                                                      Value = x.CategoryID.ToString()//burası value member olarak geçer, yani arka planda bu kısmın id değerini tutar
                                                  }).ToList();
            ViewBag.category = categoryValue;
            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            switch (headingValue.HeadingStatus)
            {
                case true:
                    headingValue.HeadingStatus = false;
                    break;
                case false:
                    headingValue.HeadingStatus = true;
                    break;
            }
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}