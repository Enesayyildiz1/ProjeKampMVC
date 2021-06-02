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
        // GET: Contact
        public ActionResult Index()
        {
            var liste=_contactManager.GetAll();
            return View(liste.Data);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactManager.GetById(id);
            return View(contactValues.Data);
        }
      
    }
}