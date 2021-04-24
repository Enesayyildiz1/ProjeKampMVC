using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading:IEntity
    {
        public int HeadingId { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingTime { get; set; }
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public ICollection<Content> Contents { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer  { get; set; }
    }
}
