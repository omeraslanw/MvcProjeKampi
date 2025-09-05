using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
    }

    //public List<CategoryClass> BlogList()
    //{
    //    List<CategoryClass> categoryClasses = new List<CategoryClass>();
    //    categoryClasses.Add(new CategoryClass()
    //    {
    //        CategoryName = "Yazılım",
    //        CategoryCount = 10
    //    });
    //    categoryClasses.Add(new CategoryClass()
    //    {
    //        CategoryName = "Seyahat",
    //        CategoryCount = 1
    //    });
    //    categoryClasses.Add(new CategoryClass()
    //    {
    //        CategoryName = "Tiyatro",
    //        CategoryCount = 4
    //    });
    //    categoryClasses.Add(new CategoryClass()
    //    {
    //        CategoryName = "Spor",
    //        CategoryCount = 8
    //    });
    //    return categoryClasses;
    //}

    //public ActionResult CategoryChart()
    //{
    //    return Json(BlogList(), JsonRequestBehavior.AllowGet);
    //}
}