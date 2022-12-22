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
        IMessageDAO Dao;

        public MessageService (MyContext context)
        {
            IMessageDAO Dao = new MessageDAO(context);
        }
         
        async Task IMessageService.DeleteMessage(Message message)
        {
            await Dao.DeleteMessage(message);
        }

        async Task<List<Message>> IMessageService.GetAllMessages()
        {
            return await Dao.GetAllMessages();
        }

        async Task<Message> IMessageService.GetMessageById(int Id)
        {
            return await Dao.GetMessageById(Id);
        }

        async Task IMessageService.CreateMessage(Message message)
        {
            await Dao.CreateMessage(message);
        }
    }
}
