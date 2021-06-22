using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager _headingManager = new HeadingManager(new HeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
       
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
          
            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _headingManager.GetByUserName(sessionInfo).Data;
            var headings = _headingManager.GetAllByWriterId(authorizeWriter.WriterId).Data;
            return View(headings);
        }
        public void GetCategory()
        {
            List<SelectListItem> categories = (from category in _categoryManager.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.CategoryId.ToString()
                                               }).ToList();
            ViewBag.liste = categories;
        }
        
        [HttpGet]
        public ActionResult AddHeading()
        {
            GetCategory();
           
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {

          
            GetCategory();
            heading.WriterId = 1;
           _headingManager.Add(heading);
           return RedirectToAction("Index","Heading");
            
           
           
        }
        [HttpGet]
        public ActionResult EditHeading(int headingId)
        {
            GetCategory();
          
            var head = _headingManager.GetById(headingId);
            return View(head.Data);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.WriterId = 1;
            _headingManager.Update(heading);
            return RedirectToAction("Index","Heading");
        }
        public ActionResult PassiveHeading(int headingId)
        {
            var head = _headingManager.GetById(headingId);
            head.Data.HeadingStatus = false;
            _headingManager.Delete(head.Data);
            return RedirectToAction("Index", "Heading");
        }
        public ActionResult ActiveHeading(int headingId)
        {
            var head = _headingManager.GetById(headingId);
            head.Data.HeadingStatus = true;
            _headingManager.Delete(head.Data);
            return RedirectToAction("Index", "Heading");
        }
    }
}