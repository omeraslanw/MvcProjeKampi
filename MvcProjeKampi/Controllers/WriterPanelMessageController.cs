using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValue = messageManager.GetListInbox(mail);
            return View(messageValue);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(mail);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string senderMail = (string)Session["WriterMail"];
            ValidationResult result = validator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = senderMail;
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