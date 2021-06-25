using Core.Utilities.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        IDataResult<Writer> GetById(int id);
        IDataResult<Writer> GetByUserName(string username);
        IDataResult<List<Writer>> GetAll();
        IResult Add(Writer writer);
        IResult Delete(Writer writer);
        IResult Update(Writer writer);
    }
}
