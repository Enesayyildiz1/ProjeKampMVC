using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager _messageManager = new MessageManager(new MessageDal());
        public ActionResult Inbox()
        {
            var list = _messageManager.GetAll();
            return View(list.Data);
        }
        public ActionResult SendBox()
        {
            return View(_messageManager.GetAllSendBox().Data);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            _messageManager.Add(message);
            return RedirectToAction("SendBox");
        }
    }
}