using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using ProjeKampMVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _categoryService = new CategoryManager(new CategoryDal());

        public ActionResult Index()
        {
           
            return View();
        }
        [Authorize]
        public ActionResult GetAllCategory()
        {
            var model = new CategoryListViewModel
            {
                Categories =_categoryService.GetAll().Data,
                Message=_categoryService.GetAll().Message
            };
            
            return View(model);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);

            if (result.IsValid)
            {
                _categoryService.Add(category); 
                return RedirectToAction("GetAllCategory");
            }
            else
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            return View(category);
        }
        public ActionResult Delete(string id)
        {
            var deletedCategory = _categoryService.GetById(Convert.ToInt32( id) );
            _categoryService.Delete(deletedCategory.Data);
            return RedirectToAction("GetAllCategory");
        }
        public ActionResult GetCategory(int id)
        {
            var updatedCategory = _categoryService.GetById(id);
            
            return View(updatedCategory.Data);
        }
        public ActionResult CategoryUpdate(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("GetAllCategory");
        }
    }
}