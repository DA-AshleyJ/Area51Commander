using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Audio;
using Area51Commander.Modules;
using Area51Commander.Entities;
using Area51Commander.Services;

namespace Area51Commander.Modules
{
    [Name("Echo Command!")]
    public class AudioService : ModuleBase<SocketCommandContext>
    {
        [Command("Say"), Alias("s")]
        [Summary("Make the bot say something")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public Task Say([Remainder]string text)
        {
            return ReplyAsync(text);
        }
    }
}