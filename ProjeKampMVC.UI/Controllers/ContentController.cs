using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _contentManager = new ContentManager(new ContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContentByHeading(int  id)
        {
            var list=_contentManager.GetByHeadingId(id);
            return View(list.Data);
        }
    }
}