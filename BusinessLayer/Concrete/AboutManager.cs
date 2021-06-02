using BusinessLayer.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AboutManager:IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(About content)
        {
            _aboutDal.Add(content);
            return new SuccessResult();
        }

        public IResult Delete(About content)
        {
            _aboutDal.Delete(content);
            return new SuccessResult();
        }

        public IDataResult<About> GetAll()
        {
            return new SuccessDataResult<About>(_aboutDal.GetList().FirstOrDefault());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(x => x.AboutId == id));
        }

        public IResult Update(About content)
        {
            _aboutDal.Update(content);
            return new SuccessResult();
        }
    }
}
