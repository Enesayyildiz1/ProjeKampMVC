using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using ProjeKampMVC.UI.Models;
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
        RoleManager _roleService = new RoleManager(new RoleDal());
        UserRoleManager _userRoleService = new UserRoleManager(new UserRoleDal());
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
        
        [HttpGet]
        public ActionResult AddRole(int id)
        {
            UserRole userRole = new UserRole();
            List<SelectListItem> roles = (from role in _roleService.GetAll().Data
                                            select new SelectListItem
                                            {
                                                Text = role.Name,
                                                Value = role.Id.ToString()
                                            }).ToList();
            userRole.UserId = id;
            userRole.RoleId = 1;
            ViewBag.liste = roles;
            return View(userRole);
        }
        public ActionResult AddRole(UserRole userRole)
        {
            _userRoleService.Add(userRole);
            return RedirectToAction("RoleList");

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