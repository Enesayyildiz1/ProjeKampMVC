using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKampMVC.UI.Controllers
{
    public class AccountController : Controller
    {UserManager _userService = new UserManager(new UserDal());
        // GET: Acoount
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {


            if (_userService.Login(userForLoginDto).Success)
            {
                Session["userName"] = userForLoginDto.UserName;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
            
          
          
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (_userService.Register(userForRegisterDto).Success)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
            
        }
    }
}