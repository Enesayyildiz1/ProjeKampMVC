using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeKampMVC.UI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public string Message { get; set; }
    }
}