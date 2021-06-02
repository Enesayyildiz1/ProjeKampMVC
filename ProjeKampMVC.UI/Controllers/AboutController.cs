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
    public class AboutController : Controller
    {
        // GET: About

        AboutManager _aboutManager = new AboutManager(new AboutDal());
        public ActionResult Index()
        {
            var aboutModels = _aboutManager.GetAll().Data;
            return View(aboutModels);
        }
        public ActionResult Update(About about)
        {
           
            _aboutManager.Update(about);
           
            return RedirectToAction("Index");
        }
    }
}