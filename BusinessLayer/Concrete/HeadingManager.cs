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
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public IResult Add(Heading heading)
        {
            _headingDal.Add(heading);
            return new SuccessResult("Başlık eklendi");
        }

        public IResult Delete(Heading heading)
        {
            _headingDal.Delete(heading);
            return new SuccessResult("Başlık silindi");
        }

        public IDataResult<List<Heading>> GetAll()
        {
            return new SuccessDataResult<List<Heading>>(_headingDal.GetList());
        }

        public IDataResult<Heading> GetById(int id)
        {
            return new SuccessDataResult<Heading>(_headingDal.Get(x => x.CategoryId == id),"Geldi");
        }

        public IResult Update(Heading heading)
        {
            _headingDal.Update(heading);
            return new SuccessResult("Başlık güncellendi");
        }
    }
}
