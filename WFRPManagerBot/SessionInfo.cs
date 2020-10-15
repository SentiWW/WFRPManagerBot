using Discord.Rest;
using Discord.WebSocket;
using System.Collections.Generic;

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
