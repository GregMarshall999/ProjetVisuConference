using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.DAO
{
    public interface IMessageDAO
    {
        Task createMessage(Message message);
        Task<List<Message>> GetAllMessages();
        Task deleteMessage(int Id);
        Task<Message> getMessageById(int Id);
    }
}
