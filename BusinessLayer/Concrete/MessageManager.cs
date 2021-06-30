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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult();
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> GetAll(string email)
        {

            return new SuccessDataResult<List<Message>>(_messageDal.GetList(x=>x.Receiver==email));
        }
        public IDataResult<List<Message>> GetAllSendBox(string email)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetList(x => x.Sender == email));
        }
        public IDataResult<Message> GetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(c=>c.MessageId==id));
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }
}
