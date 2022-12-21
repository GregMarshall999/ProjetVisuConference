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
        Task reateMessage(Message message);
        Task<List<Message>> GetAllMessages();
        Task DeleteMessage(Message message);
        Task<Message> GetMessageById(int Id);
    }
}
