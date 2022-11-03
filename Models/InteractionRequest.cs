using Newtonsoft.Json;

namespace DiscordBotInteractions.Models
{
    internal class InteractionRequest
    {
        public InteractionType Type { get; set; }
        public string Token { get; set; }
        public Member Member { get; set; }
        public string Id { get; set; }
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
        [JsonProperty("app_permissions")]
        public string AppPermissions { get; set; }
        [JsonProperty("guild_locale")]
        public string GuildLocale { get; set; }
        public string Locale { get; set; }
        public InteractionData Data { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
