using Newtonsoft.Json;
using System.Collections.Generic;

namespace DiscordBotInteractions.Models
{
    internal class AllowedMentions
    {
        public IEnumerable<string> Parse { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> Users { get; set; }
        [JsonProperty("replied_user")]
        public bool RepliedUser { get; set; }
    }
}
