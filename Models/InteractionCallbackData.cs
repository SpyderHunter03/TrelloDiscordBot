using Newtonsoft.Json;
using System.Collections.Generic;

namespace DiscordBotInteractions.Models
{
    internal class InteractionCallbackData
    {
        public bool? TTS { get; set; }
        public string Content { get; set; }
        public IEnumerable<Embed> Embeds { get; set; }
        [JsonProperty("allowed_mentions")]
        public AllowedMentions AllowedMentions { get; set; }
        public int Flags { get; set; }
        public IEnumerable<Component> Components { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
