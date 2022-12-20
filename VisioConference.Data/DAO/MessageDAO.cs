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
    internal class MessageDAO : AbstractDAO, IMessageDAO
    {
        public MessageDAO(MyContext context) : base(context)
        {
        }

        async Task IMessageDAO.createMessage(Message message)
        {
            context.Message.Add(message);
            await context.SaveChangesAsync();
        }

        async Task IMessageDAO.deleteMessage(int Id)
        {
            Message m = await context.Message.FindAsync(Id);

            if (m != null)
            {
               context.Message.Remove(m);
               await context.SaveChangesAsync();
            }
            else throw new Exception("Message introuvable");
        }

        async Task<List<Message>> IMessageDAO.GetAllMessages()
        {
            return await context.Message.AsNoTracking().ToListAsync();
        }

        async Task<Message> IMessageDAO.getMessageById(int Id)
        {
            Message m = await context.Message.FindAsync(Id);
            if (m != null)
                return m;
            else throw new Exception("Message introuvable");
        }
    }
}
