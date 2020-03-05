using System;

namespace Commander
{
    public class GuildConfig
    {
        public ulong Id { get; set; }
        public string Prefix { get; set; }
        public string CurrencyName { get; set; }
        public string SuccessEmoji { get; set; }
        public DateTime? BannedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
