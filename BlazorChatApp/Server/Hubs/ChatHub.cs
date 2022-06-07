using BlazorChatApp.Server.Data;
using BlazorChatApp.Shared;
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
		 
		private readonly PreviousChatArchive previousChatArchive;

		public ChatHub(PreviousChatArchive previousChatArchive)
		{
			this.previousChatArchive = previousChatArchive;
		}

		public async Task JoinRoom(string token)
        {
			await Groups.AddToGroupAsync(Context.ConnectionId, token);
        }
		public async Task SendMessage(DateTime dateTime, string user, string message, string token)
		{
			ChatData chatData = new ChatData { User = user, Message = message };

			if (previousChatArchive.Chats.ContainsKey(token))
			{
				previousChatArchive.Chats[token].Add(chatData);
			}
			else
			{
				previousChatArchive.Chats.Add(token, new List<Shared.ChatData> { chatData });
			}

			await Clients.Group(token).SendAsync("ReceiveMessage", dateTime, user, message);
			Console.WriteLine($"[{token}: {user} {dateTime}] : {message}");
		}

	}
}
