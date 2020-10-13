using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRPManagerBot
{
    public class SessionInfo
    {
        public static Dictionary<SocketUser, RestUserMessage> activeSignups = new Dictionary<SocketUser, RestUserMessage>();
        public SocketUser socketUser;
        public RestUserMessage restUserMessage;

        public SessionInfo(RestUserMessage restUserMessage, SocketUser socketUser)
        {
            this.restUserMessage = restUserMessage;
            this.socketUser = socketUser;
            activeSignups.Add(socketUser, restUserMessage);
        }
    }
}
