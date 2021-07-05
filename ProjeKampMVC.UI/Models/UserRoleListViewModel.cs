using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKampMVC.UI.Models
{
    public class UserRoleListViewModel
    {
        public int UserId { get; set; }
        public List<Role> Roles { get; set; }
    }
}