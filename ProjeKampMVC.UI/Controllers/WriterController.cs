using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager _writerService = new WriterManager(new WriterDal());

      

        public ActionResult Index()
        {

            var list = _writerService.GetAll();
            return View(list.Data);
        }
    }
}