using Newtonsoft.Json;

namespace DiscordBotInteractions.Models
{
    internal class Attachment
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        [JsonProperty("proxy_url")]
        public string ProxyUrl { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public bool? Ephemeral { get; set; }
    }
}
