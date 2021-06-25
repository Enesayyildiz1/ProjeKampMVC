using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class DefaultController : Controller
    {

        HeadingManager headingManager = new HeadingManager(new HeadingDal());
        ContentManager contentManager = new ContentManager(new ContentDal());
        // GET: Default
        //heading kontroller yaz admin layoutu çek headingsleri sidebara bas
        public ActionResult Headings()
        {
            var liste = headingManager.GetAll().Data;
              return View(liste);
        }
        public PartialViewResult Index(int id=0)
        {
            var liste = contentManager.GetByHeadingId(id).Data;
            return PartialView(liste);
        }
    }
}