using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatApp.Client
{
    public class AppState
    {
        public string UserName { get; set; }
        public List<string> Rooms { get; set; } = new List<string>();

        public string Room { get; set; }

        public Action AppStateUpdated { get; set; }
    }
}
