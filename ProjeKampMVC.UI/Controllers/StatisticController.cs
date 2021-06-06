using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
        HeadingManager _headingManager = new HeadingManager(new HeadingDal());
        WriterManager _writerManager = new WriterManager(new WriterDal());

        public ActionResult Index()
        {
            var categoryCount=_categoryManager.GetAll().Data.Count();
            var headingOfSoftware = _headingManager.GetAll().Data.Where(x => x.HeadingName == "Yazılım").Count();
            var writersNameContainsALetter = _writerManager.GetAll().Data.Where(x=>x.WriterName.Contains("a")).Count();
            var activeCategories = _categoryManager.GetAll().Data.Where(x => x.CategoryStatus ==true).Count();
            var noactiveCategories = _categoryManager.GetAll().Data.Where(x => x.CategoryStatus == false).Count();
            var difference = noactiveCategories - activeCategories;
            var categoryNameToHaveMaxHeading = _categoryManager.GetAll().Data.Where(p => p.CategoryId == _headingManager.GetAll().Data.GroupBy(x => x.CategoryId).OrderByDescending(w => w.Count()).Select(c => c.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.CategoryCount = categoryCount;
            ViewBag.HeadingOfSoftware = headingOfSoftware;
            ViewBag.WritersNameContainsALetter = writersNameContainsALetter;
            ViewBag.Difference = difference;
            ViewBag.CategoryNameToHaveMaxHeading = categoryNameToHaveMaxHeading;
            return View();
        }
    }
}