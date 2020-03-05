using Discord;
using Discord.Commands;
using Discord.Rest;
using System.IO;
using System.Threading.Tasks;

namespace Commander
{
    public class DogeyModuleBase : ModuleBase<SocketCommandContext>
    {
        protected readonly RootController _root;

        public DogeyModuleBase(RootController root)
        {
            _root = root;
        }

        public Task<IUserMessage> ReplyEmbedAsync(Embed embed)
            => ReplyAsync("", false, embed, null);
        public Task<IUserMessage> ReplyEmbedAsync(EmbedBuilder builder)
            => ReplyAsync("", false, builder.Build(), null);

        public Task ReplyReactionAsync(IEmote emote)
            => Context.Message.AddReactionAsync(emote);

        
    }
}
