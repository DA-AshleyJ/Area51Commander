using Commander;
using Discord;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander
{
    public class RootController : DbController<RootDatabase>
    {
        public RootController(RootDatabase db) : base(db) { }

        public Task<ChannelConfig> GetConfigAsync(IGuildChannel channel)
            => channel == null ? Task.FromResult(default(ChannelConfig)) : _db.ChannelConfigs.SingleOrDefaultAsync(x => x.Id == channel.Id);

    
        public async Task<ChannelConfig> GetOrCreateConfigAsync(IGuildChannel channel)
        {
            var config = await GetConfigAsync(channel);
            if (config != null) return config;
            return await CreateAsync(new ChannelConfig { Id = channel.Id, GuildId = channel.GuildId });
        }

        public async Task<IEnumerable<ReactionRole>> GetReactionRolesAsync()
       => await _db.ReactionRoles.ToListAsync();
        public async Task<IEnumerable<ReactionRole>> GetReactionRolesAsync(ulong guildId)
            => await _db.ReactionRoles.Where(x => x.GuildId == guildId).ToListAsync();

        public async Task<ChannelConfig> CreateAsync(ChannelConfig config)
        {
            await _db.ChannelConfigs.AddAsync(config);
            await SaveAsync();
            return config;
        }

        public Task SaveAsync()
            => _db.SaveChangesAsync();
    }
}
