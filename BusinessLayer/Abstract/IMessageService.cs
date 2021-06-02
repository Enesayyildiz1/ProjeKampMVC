using Core.Utilities.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        IDataResult<Message> GetById(int id);
        IDataResult<List<Message>> GetAll();
        IResult Add(Message message);
        IResult Delete(Message message);
        IResult Update(Message message);
    }
}
