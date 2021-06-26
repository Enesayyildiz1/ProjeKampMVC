using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using PagedList;
using PagedList.Mvc;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager _headingManager = new HeadingManager(new HeadingDal());
        ContentManager _contentManager = new ContentManager(new ContentDal());
        CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
        WriterManager _writerManager = new WriterManager(new WriterDal());
       
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
          
            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _writerManager.GetByUserName(sessionInfo).Data;
            var headings = _headingManager.GetAllByWriterId(authorizeWriter.WriterId).Data;
            return View(headings);
        }
        public ActionResult MyContent()
        {

            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _writerManager.GetByUserName(sessionInfo).Data;
            var contents = _contentManager.GetAllByWriterId(authorizeWriter.WriterId).Data;
            return View(contents);
        }
        public ActionResult AllHeading(int? page)
        {
            var headings = _headingManager.GetAll2().Data.ToPagedList(page ?? 1,3);

            return View(headings);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _writerManager.GetByUserName(sessionInfo).Data;

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = authorizeWriter.WriterId;
            content.ContentStatus = true;
            _contentManager.Add(content);
            return RedirectToAction("MyContent");

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

            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _writerManager.GetByUserName(sessionInfo).Data;
            GetCategory();
            heading.WriterId = authorizeWriter.WriterId;
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
            string sessionInfo = (string)Session["UserName"];
            var authorizeWriter = _writerManager.GetByUserName(sessionInfo).Data;
            heading.WriterId = authorizeWriter.WriterId;
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