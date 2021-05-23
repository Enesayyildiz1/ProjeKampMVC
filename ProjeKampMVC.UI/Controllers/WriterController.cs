using BusinessLayer.Abstract;
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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager _writerService = new WriterManager(new WriterDal());

      

        public ActionResult Index()
        {

            var list = _writerService.GetAll();
            return View(list.Data);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(writer);


            if (result.IsValid)
            {
                _writerService.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            return View(writer);
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writer = _writerService.GetById(id);
            return View(writer.Data);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            _writerService.Update(writer);
            return RedirectToAction("Index");
        }
    }
}