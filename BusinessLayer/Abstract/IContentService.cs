using Core.Utilities.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
     
        IDataResult<List<Content>> GetAll();
        IResult Add(Content content);
        IResult Delete(Content content);
        IResult Update(Content content);
        IDataResult<List<Content>> GetByHeadingId(int headingId);
        
    }
}
