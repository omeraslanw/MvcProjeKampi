using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCatogoryController : Controller
    {
        CategoryManager manager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var categoryValues = manager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult validationResult = validator.Validate(category);
            if (validationResult.IsValid)
            {
                manager.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = manager.GetByID(id);
            manager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = manager.GetByID(id);
            //işlem yapacağımız kategorinin id değerini hafızaya alır
            return View(categoryValue);
            //Güncelleme işleminin ardından değişen değerlerle birlikte Index sayfası sunucu tarafından sayfaya gönderilir
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            manager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
    }
}