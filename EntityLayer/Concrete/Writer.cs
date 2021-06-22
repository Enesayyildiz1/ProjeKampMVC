
using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer:IEntity
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterUsername { get; set; }
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        public string WriterAbout { get; set; }
         [StringLength(100)]
        public string WriterTitle { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
