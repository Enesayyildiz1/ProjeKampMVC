using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skill
        ProjeContext db = new ProjeContext();
        public ActionResult Index()
        {
            var liste= db.Set<Skill>().ToList();



            return View(liste);
        }
    }
}