using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Commander
{
    public class DogeyCommandContext 
    {
        public DiscordSocketClient Client { get; }
        public SocketGuild Guild { get; }
        public ISocketMessageChannel Channel { get; }
        public SocketUser User { get; }
        public SocketUserMessage Message { get; }

        public bool IsPrivate => Channel is IPrivateChannel;

        public DogeyCommandContext(DiscordSocketClient client, SocketUserMessage msg, SocketUser user = null)
        {
            Client = client;
            Guild = (msg.Channel as SocketGuildChannel)?.Guild;
            Channel = msg.Channel;
            User = user ?? msg.Author;
            Message = msg;
        }

    
    }
}
