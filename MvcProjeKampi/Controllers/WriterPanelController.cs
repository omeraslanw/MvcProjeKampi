using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string mail = (string)Session["WriterMail"];
            int id = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManager.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult MyHeading(string mail)
        {
            mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var headingValues = headingManager.GetListByWriter(writerIdInfo);
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,//burası display member olarak geçer, yani arayüzde gösterilecek kısımdır
                                                      Value = x.CategoryID.ToString()//burası value member olarak geçer, yani arka planda bu kısmın id değerini tutar
                                                  }).ToList();
            ViewBag.category = categoryValue;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int page = 1)
        {
            var headings = headingManager.GetList().ToPagedList(page, 4);
            return View(headings);
        }
    }
}