using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        ContactManager _contactManager = new ContactManager(new ContactDal());
        MessageManager _messageManager = new MessageManager(new MessageDal());
        public ActionResult Inbox()
        {
            messagesCount();
            var list = _messageManager.GetAll("admin@gmail.com");
            return View(list.Data);
        }
        public ActionResult SendBox()
        {
            messagesCount();
            return View(_messageManager.GetAllSendBox("admin@gmail.com").Data);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            messagesCount();
            return View();
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "NewMessage")]
        public ActionResult NewMessage(Message message)
        {
            messagesCount();
            MessageValidator validations = new MessageValidator();
            
            message.MessageDate = DateTime.Now;
            message.Sender = "admin@gmail.com";
ValidationResult result = validations.Validate(message);
            if (result.IsValid)
            {
                _messageManager.Add(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            return View();
        }
        List<Message> sketches = new List<Message>();
        [HttpGet]
        public ActionResult CreateSketch()
        {
            return View(sketches);

        }
         [HttpPost]
        [MultipleButton(Name = "action", Argument = "CreateSketch")]
       
        public ActionResult CreateSketch(Message message)
        {
            message.MessageDate = DateTime.Now;
            message.Sender = "admin@gmail.com";
            sketches.Add(message);
            
            return View(sketches);

        }
       
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }

           
        }
        public void messagesCount()
        {
            ViewBag.numberOfCommunicationMessages = _contactManager.GetAll().Data.Count;
            ViewBag.numberOfInMessages = _messageManager.GetAll("admin@gmail.com").Data.Count;
            ViewBag.numberOfSendMessages = _messageManager.GetAllSendBox("admin@gmail.com").Data.Count;
        }
        public PartialViewResult GetMessageDetails(int id)
        {
            messagesCount();
            var messageValues = _messageManager.GetById(id);
            return PartialView(messageValues.Data);
        }
    }
}