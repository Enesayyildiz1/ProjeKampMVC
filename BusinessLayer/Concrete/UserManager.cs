using BusinessLayer.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public object Session { get; private set; }

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByUserNameAndPassword(string userName)
        {
            return new SuccessDataResult<User>(userDal.Get(x => x.UserName == userName));
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<UserRoleDto>> GetUserRoles(User user)
        {
            return new SuccessDataResult<List<UserRoleDto>>(userDal.GetUserRoles(user));
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            byte[] passwordHash, passwordSalt;
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userForRegisterDto.Password));
            var user = new User
            {
                UserName=userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };
            userDal.Add(user);
            return new SuccessDataResult<User>(user);
        }
       
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = GetByUserNameAndPassword(userForLoginDto.UserName).Data;
            if (user == null)
            {
                return new ErrorDataResult<User>("Kullanıcı yok");
            }
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userForLoginDto.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return new ErrorDataResult<User>("Şifreler Eşleşmiyor");
                    }
                }
                 AuthenticationHelper.CreateAuthCookie(
                            new Guid(),
                            user.UserName,
                            user.Email,

                            DateTime.Now.AddSeconds(10),
                            GetUserRoles(user).Data.Select(u => u.RoleName).ToArray(),
                            false,
                            user.FirstName,
                           user.LastName); 
                return new SuccessDataResult<User>(user);
            }
           
            
           



         
        }

        public IDataResult<List<UserRoleDto>> GetRoles()
        {
            return new SuccessDataResult<List<UserRoleDto>>(userDal.GetUserRoles());
        }

        public IDataResult<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
