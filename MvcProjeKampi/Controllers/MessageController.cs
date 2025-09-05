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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();

        public ActionResult Inbox(string mail)
        {
            var messageValue = messageManager.GetListInbox(mail);
            return View(messageValue);
        }

        public ActionResult SendBox(string mail)
        {
            var messageValue = messageManager.GetListSendbox(mail);
            return View(messageValue);
        }

        public ActionResult GetInBoxDetails(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return View(messageValues);
        }

        public ActionResult GetSendBoxDetails(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult AddNewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewMessage(Message message)
        {
            ValidationResult result = validator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
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
    }
}