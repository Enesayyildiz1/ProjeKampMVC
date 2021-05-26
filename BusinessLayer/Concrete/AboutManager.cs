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
            throw new NotImplementedException();
        }

        public IResult Delete(About content)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<About>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(About content)
        {
            throw new NotImplementedException();
        }
    }
}
