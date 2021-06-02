using Core.Utilities.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IDataResult<About> GetById(int id);
        IDataResult<About> GetAll();
        IResult Add(About content);
        IResult Delete(About content);
        IResult Update(About content);
       
    }
}
