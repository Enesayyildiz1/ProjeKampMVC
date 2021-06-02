using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message:IEntity
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string Sender { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        [StringLength(50)]
        public string Subject{ get; set; }
        [StringLength(50)]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
