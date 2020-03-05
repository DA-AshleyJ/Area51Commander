using System;

namespace Commander
{
    public class UserConfig
    {
        public ulong Id { get; set; }
        public DateTime? BannedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
