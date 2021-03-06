using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace ProjeKampMVC.UI.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager _headingManager = new HeadingManager(new HeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
        WriterManager _writerManager = new WriterManager(new WriterDal());
        public ActionResult Index()
        {
            var headings=_headingManager.GetAll2();
            
            return View(headings.Data);
        }
        public ActionResult HeadingReport()
        {
            var headings = _headingManager.GetAll2();

            return View(headings.Data);
        }
        public void GetCategory()
        {
            List<SelectListItem> categories = (from category in _categoryManager.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text=category.CategoryName,
                                                   Value=category.CategoryId.ToString()
                                               }).ToList();
            ViewBag.liste = categories;
        }
        public void GetWriter()
        {
            List<SelectListItem> writers = (from writer in _writerManager.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = writer.WriterName,
                                                   Value = writer.WriterId.ToString()
                                               }).ToList();
            ViewBag.liste2 = writers;
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            GetCategory();
            GetWriter();
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {

            HeadingValidator validations = new HeadingValidator();
            ValidationResult result = validations.Validate(heading);

            if (result.IsValid)
            {
                _headingManager.Add(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditHeading(int headingId)
        {
            GetCategory();
            GetWriter();
            var head = _headingManager.GetById(headingId);
            return View(head.Data);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        public ActionResult PassiveHeading(int headingId)
        {
            var head = _headingManager.GetById(headingId);
            head.Data.HeadingStatus = false;
            _headingManager.Delete(head.Data);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveHeading(int headingId)
        {
            var head = _headingManager.GetById(headingId);
            head.Data.HeadingStatus = true;
            _headingManager.Delete(head.Data);
            return RedirectToAction("Index");
        }
    }
}