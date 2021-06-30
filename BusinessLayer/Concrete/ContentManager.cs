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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public IResult Add(Content content)
        {
            _contentDal.Add(content);
            return new SuccessResult("İçerik Eklendi");
        }

        public IResult Delete(Content content)
        {
            _contentDal.Delete(content);
            return new SuccessResult("İçerik Silindi");
        }

        public IDataResult<List<Content>> GetAll(string search)
        {
            return new SuccessDataResult<List<Content>>(_contentDal.GetList(x=>x.ContentValue.Contains(search)), "İçerikler listelendi");
        }

        public IDataResult<List<Content>> GetAllByWriterId(int id)
        {
            return new SuccessDataResult<List<Content>>(_contentDal.GetContentsByWriter(id));
        }

        public IDataResult<List<Content>> GetByHeadingId(int headingId)
        {
            return new SuccessDataResult<List<Content>>(_contentDal.GetContentsByHeading(headingId));
        }

     

        public IResult Update(Content content)
        {
            _contentDal.Update(content);
            return new SuccessResult("İçerik güncellendi");
        }
    }
}
