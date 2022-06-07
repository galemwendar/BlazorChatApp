using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatApp.Server.Hubs
{
	public class ChatHub:Hub
	{
		public async Task SendMessage(DateTime dateTime, string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", dateTime, user, message);
			Console.WriteLine($"[{dateTime}: {user}] : {message}");
		}

	}
}
