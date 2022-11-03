using Newtonsoft.Json;
using System;

namespace DiscordBotInteractions.Models
{
    internal class Member
    {
        public User User { get; set; }
        public string[] Roles { get; set; }
        [JsonProperty("premium_since")]
        public DateTime? PremiumSince { get; set; }
        public string Permissions { get; set; }
        public bool Pending { get; set; }
        public string Nick { get; set; }
        public bool Mute { get; set; }
        [JsonProperty("joined_at")]
        public DateTime? JoinedAt { get; set; }
        [JsonProperty("is_pending")]
        public bool IsPending { get; set; }
        public bool Deaf { get; set; }
    }
}
