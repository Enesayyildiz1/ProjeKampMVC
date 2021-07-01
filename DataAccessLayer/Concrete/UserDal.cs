using DataAccessLayer.Abstract;
using DevFramework.Core.DataAccess.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, ProjeContext>, IUserDal
    {
        public List<UserRoleDto> GetUserRoles(User user=null)
        {
            if (user==null)
            {
                using (ProjeContext db = new ProjeContext())
                {
                    var liste = from ur in db.UserRoles
                                join u in db.Users
                                on ur.UserId equals u.Id
                                join r in db.Roles
                                on ur.RoleId equals r.Id
                            
                                select new UserRoleDto { UserId = u.Id, RoleName = r.Name, UserName = u.UserName };
                    return liste.ToList();
                }
            }
            else
            {
                using (ProjeContext db = new ProjeContext())
                {
                    var liste = from ur in db.UserRoles
                                join u in db.Users
                                on ur.UserId equals u.Id
                                join r in db.Roles
                                on ur.RoleId equals r.Id
                                where ur.UserId == user.Id
                                select new UserRoleDto { UserId = u.Id, RoleName = r.Name, UserName = u.UserName };
                    return liste.ToList();
                }
            }
            
        }
    }
}
