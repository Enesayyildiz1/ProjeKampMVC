using ProjeKampMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categories = new List<CategoryClass>();
            categories.Add(new CategoryClass()
            {
                CategoryCount=8,
                CategoryName="Yazılım"
            });
            categories.Add(new CategoryClass()
            {
                CategoryCount =3,
                CategoryName = "Seyahat"
            });
            categories.Add(new CategoryClass()
            {
                CategoryCount = 10,
                CategoryName = "Kişisel Gelişim"
            });
            categories.Add(new CategoryClass()
            {
                CategoryCount = 12,
                CategoryName = "Teknoloji"
            });
            categories.Add(new CategoryClass()
            {
                CategoryCount =11,
                CategoryName = "Spor"
            });
            return categories;

        }
    }
}