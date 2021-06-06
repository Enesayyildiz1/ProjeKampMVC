using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new ContactDal());
        MessageManager _messageManager = new MessageManager(new MessageDal());
        // GET: Contact
        public ActionResult Index()
        {
            messagesCount();
            var liste=_contactManager.GetAll();
            return View(liste.Data);
        }
        public ActionResult GetContactDetails(int id)
        {
            messagesCount();
            var contactValues = _contactManager.GetById(id);
            return View(contactValues.Data);
        }
        public void messagesCount()
        {
            ViewBag.numberOfCommunicationMessages = _contactManager.GetAll().Data.Count;
            ViewBag.numberOfInMessages = _messageManager.GetAll().Data.Count;
            ViewBag.numberOfSendMessages = _messageManager.GetAllSendBox().Data.Count;
        }      
    }
}