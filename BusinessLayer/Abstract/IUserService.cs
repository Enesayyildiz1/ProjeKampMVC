using Core.Utilities.Results;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
    }
}
