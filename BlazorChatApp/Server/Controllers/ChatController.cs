using BlazorChatApp.Server.Data;
using BlazorChatApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChatApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
		private readonly PreviousChatArchive previousChatArchive;

		public ChatController(PreviousChatArchive previousChatArchive)
		{
			this.previousChatArchive = previousChatArchive;
		}

		[HttpGet("{roomName}")]
		public IEnumerable<ChatData> Get([FromRoute] string roomName)
		{
			if (previousChatArchive.Chats.ContainsKey(roomName))
				return previousChatArchive.Chats[roomName];
			return new ChatData[0];
		}
	}
}

