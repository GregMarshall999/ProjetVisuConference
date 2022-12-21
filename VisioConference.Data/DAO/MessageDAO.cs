using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.DAO;
using VisioConference.Data;
using VisioConference.Models;

namespace VisioDAO.DAO
{
    public class MessageDAO : AbstractDAO, IMessageDAO
    {
        public MessageDAO(MyContext context) : base(context)
        {
        }

        async Task IMessageDAO.CreateMessage(Message message)
        {
            context.Message.Add(message);
            await context.SaveChangesAsync();
        }

        async Task IMessageDAO.DeleteMessage(Message message)
        {
            Message m = await context.Message.FindAsync(message.Id);

            if (m != null)
            {
               context.Message.Remove(message);
               await context.SaveChangesAsync();
            }
            else throw new Exception("Message introuvable");
        }

        async Task<List<Message>> IMessageDAO.GetAllMessages()
        {
            return await context.Message.AsNoTracking().ToListAsync();
        }

        async Task<Message> IMessageDAO.GetMessageById(int Id)
        {
            Message m = await context.Message.FindAsync(Id);
            if (m != null)
                return m;
            else throw new Exception("Message introuvable");
        }
    }
}
