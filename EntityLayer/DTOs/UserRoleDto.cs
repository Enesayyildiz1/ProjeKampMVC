using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
