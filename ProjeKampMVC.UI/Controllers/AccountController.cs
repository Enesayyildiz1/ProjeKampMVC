﻿using BusinessLayer.Concrete;
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
    [AllowAnonymous ]
    public class AccountController : Controller
    {UserManager _userService = new UserManager(new UserDal());
        // GET: Acoount
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RoleList()
        {
            var liste = _userService.GetRoles().Data;
            return View(liste);
        }

        [HttpPost]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {


            if (_userService.Login(userForLoginDto).Success)
            {
                Session["UserName"] = userForLoginDto.UserName;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.ErrorMessage = _userService.Login(userForLoginDto).Message;
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