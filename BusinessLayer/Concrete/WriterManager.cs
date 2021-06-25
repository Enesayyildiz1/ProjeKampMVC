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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public IResult Add(Writer writer)
        {
            writer.RegisterDate = DateTime.Now;
            _writerDal.Add(writer);
            return new SuccessResult("Yazar başarıyla kaydedildi");
        }

        public IResult Delete(Writer writer)
        {
            
            _writerDal.Delete(writer);
            return new SuccessResult("Yazar başarıyla silindi");
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetList());
        }

        public IDataResult<Writer> GetById(int id)
        {
          
            return new SuccessDataResult<Writer>(  _writerDal.Get(x=>x.WriterId==id),"Yazar geldi");
        }

        public IDataResult<Writer> GetByUserName(string username)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(x => x.WriterUsername == username), "Yazar geldi");
        }

        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult("Yazar güncellendi");
        }
    }
}
