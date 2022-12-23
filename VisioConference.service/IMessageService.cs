using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Models;

namespace VisioConference.Service
{
    public interface IMessageService
    {
        Task CreateMessage(Message message, Utilisateur createurDuMessage, Salon salon);
        Task<List<Message>> GetAllMessages();
        Task DeleteMessage(Message message);
        Task<Message> GetMessageById(int Id);
    }
}
