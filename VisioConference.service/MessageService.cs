using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;
using VisioDAO.DAO;

namespace VisioConference.Service
{
    public class MessageService : IMessageService
    {
        IMessageDAO _Dao;

        public MessageService(IMessageDAO Dao, MyContext context)
        {
            _Dao = Dao;
        }
         
        async Task IMessageService.DeleteMessage(Message message)
        {
            await _Dao.DeleteMessage(message);
        }

        async Task<List<Message>> IMessageService.GetAllMessages()
        {
            return await _Dao.GetAllMessages();
        }

        async Task<Message> IMessageService.GetMessageById(int Id)
        {
            return await _Dao.GetMessageById(Id);
        }

        async Task IMessageService.CreateMessage(Message message)
        {
            await _Dao.CreateMessage(message);
        }
    }
}
