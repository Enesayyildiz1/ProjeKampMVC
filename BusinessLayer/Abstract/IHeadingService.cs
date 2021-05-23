using Core.Utilities.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        IDataResult<Heading> GetById(int id);
        IDataResult<List<Heading>> GetAll();
        IResult Add(Heading heading);
        IResult Delete(Heading heading);
        IResult Update(Heading heading);
    }
}
