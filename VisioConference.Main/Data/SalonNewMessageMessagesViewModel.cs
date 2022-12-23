using System.Diagnostics;
using VisioConference.Models;

namespace VisioConference.Main.Data
{
	public class SalonNewMessageMessagesViewModel
	{
		public Salon Salon { get; set; }
		public Message NewMessage { get; set; }
		public ICollection<Message> Messages { get; set; }
	}
}
