using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Discord.Audio;
using Area51Commander.Modules;
using Area51Commander.Entities;
using Area51Commander.Services;
using System.Net.Http;
using System;
using HtmlAgilityPack;
using System.Linq;

namespace Area51Commander.Modules
{
    
    [Name("Echo Command!")]
    public class AudioService : ModuleBase<SocketCommandContext>
    {
        public readonly DiscordSocketClient _client;
        [Command("Say"), Alias("s")]
        [Summary("Make the bot say something")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public Task Say([Remainder]string text)
        {
            return ReplyAsync(text);
        }

        [Command("version")]
        [Summary("Version of the bot")]
        public async Task Version()
        {
            ulong id = 683859016631320591;
            var IMessageChannel = _client.GetChannel(id) as IMessageChannel;
         
            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 255, 0),
                Description = "```The current version of the bot that this discord is running is: Version 1.5.1```",
                Title = "BOT ONLINE",
            };
            var Auther = new EmbedAuthorBuilder()
                .WithName("Area51 Commander")
                .WithIconUrl("https://i.imgur.com/xqfHEin.png");
            builder.WithAuthor(Auther);
            builder.WithFooter("Created by Ashley Johnson - 1¡LuCkY√#5492");
            await IMessageChannel.SendMessageAsync("", false, builder.Build());
        }

        [Command("Admin"), Alias("helpme")]
        [Summary("Contacts ingame Admin for help on our servers")]
        public async Task IngameHelp(SocketGuildUser user, [Remainder] string report)
        {
       
          // ulong admin1 = 422737692120449024;
         // var admin2 = "193196525470351361";            
        //  var admin4 = "566947841881145344";
        //  var admin5 = "345240458730930176";
            //var admin6 = "350998212322263041";
            //var admin7 = "533425948150726677";
            //var admin8 = "634501057694793747";
            //var admin9 = "428410737661181952";
            //var admin10 = "120309862025527297";

            var builder = new EmbedBuilder()
            {
                Color = new Color(0, 255, 0),
                Description = $"Hello, there is currently an open report. Details are as follows:",
                Title = "Report open!",
            };
            builder.AddField(x =>
            {
                x.Name = user.Nickname + user.Username;
                x.Value = $"```{report}```";
                x.IsInline = false;
            });
            await Discord.UserExtensions.SendMessageAsync(user,null,false, builder.Build());


        }

        [Command("Servers")]
        [Summary("Gets the stats for Servers")]
        public async Task BattleField()
        {
            var html = @"https://battlelog.battlefield.com/bf4/servers/show/pc/fc8ee6f6-ae10-441f-a305-f266e03f342c/AE51-Area51-Infantry-No-Tryhard-Zone/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5"); 

            var html1 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/4c9969f6-f711-4b27-b83f-b03a05e4d427/AE51-Locker-24-7-welcome-to-the-meat-grinder/";
            var htmlDoc1 = web.Load(html1);
            var node1 = htmlDoc1.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html2 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/d9a11d77-bd27-4ff6-a906-0410f2086855/1-AE51-Area51-dogtag-search-and-frostbite/";
            var htmlDoc2 = web.Load(html2);
            var node2 = htmlDoc2.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html3 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/882c398d-cf71-4352-86c6-0f59b00cc9ca/AE51-24-7-Pearl-Market-Only/";
            var htmlDoc3 = web.Load(html3);
            var node3 = htmlDoc3.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html4 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/bd71d80e-8ec7-4c0e-90dd-96d84b06eafa/AE51-Area51-Rush-Hardcore-Only-10-vs-10-meat-grinder/";
            var htmlDoc4 = web.Load(html4);
            var node4 = htmlDoc4.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html5 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/09d0e6a3-a97b-403c-ab1c-e0dcfce039e9/AE51-Area51-Gun-Master-10v10/";
            var htmlDoc5 = web.Load(html5);
            var node5 = htmlDoc5.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html6 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/6e4d07d4-d374-4164-ba46-490ff80ff8fb/AE51-Good-old-official-vanilla-conquest-large/";
            var htmlDoc6 = web.Load(html6);
            var node6 = htmlDoc6.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html7 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/b52e4cbf-f851-45c1-8867-ad720eece9ad/AE51-HOT-CHICKS-Silk-Road-Only-Fast-spawn-1pStart/";
            var htmlDoc7 = web.Load(html7);
            var node7 = htmlDoc7.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html8 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/f88fdc44-6733-49f8-8890-ed8d5e3f1476/AE51-The-Madhouse-CQL-Fast-Vehichle-Respawn/";
            var htmlDoc8 = web.Load(html8);
            var node8 = htmlDoc8.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");

            var html9 = @"https://battlelog.battlefield.com/bf4/servers/show/pc/e97c8c27-7b3a-4dea-a345-0ee203bcddfe/xxx-AE51-Area51-SM-torture-cellar-doing-painful-assignments/";
            var htmlDoc9 = web.Load(html9);
            var node9 = htmlDoc9.DocumentNode.SelectSingleNode("//*[@id='server-page-info']/div[2]/div[1]/section/h5");
            var builder = new EmbedBuilder()
            {
                Color = new Color(189, 16, 224),
                Description = $"",
                Title = "Server Population",               
            };
            var footer = new EmbedFooterBuilder()
                .WithIconUrl("https://i.imgur.com/xqfHEin.png");
            var Auther = new EmbedAuthorBuilder()
                .WithName("Area51 Commander")
                .WithIconUrl("https://i.imgur.com/xqfHEin.png");
            builder.WithAuthor(Auther);
            builder.WithFooter(footer);
            builder.WithCurrentTimestamp();
            builder.AddField(x =>
            {
                x.Name = "No Try Hard";
                x.Value = node.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Locker 24/7";
                x.Value = node1.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Dogtag Search";
                x.Value = node2.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "24/7 Pearl Market";
                x.Value = node3.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Rush Hardcore";
                x.Value = node4.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Gun Master";
                x.Value = node5.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Vanilla Conquest Large";
                x.Value = node6.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "Hot Chicks";
                x.Value = node7.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "The Mad House";
                x.Value = node8.InnerText;
                x.IsInline = true;
            });
            builder.AddField(x =>
            {
                x.Name = "SM Torture Cellar";
                x.Value = node9.InnerText;
                x.IsInline = true;
            });
            await ReplyAsync("", false, builder.Build());
        }
    }


}