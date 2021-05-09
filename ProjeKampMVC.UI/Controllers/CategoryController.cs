using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
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
        CategoryManager categoryService = new CategoryManager(new CategoryDal());

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetAllCategories()
        {
            var model = new CategoryListViewModel
            {
                Categories =categoryService.GetAll().Data,
                Message=categoryService.GetAll().Message
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
                categoryService.Add(category); 
                return RedirectToAction("GetAllCategories");
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
    }
}