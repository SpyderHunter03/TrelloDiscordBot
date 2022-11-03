using Newtonsoft.Json;

namespace DiscordBotInteractions.Models
{
    internal class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Discriminator { get; set; }
        [JsonProperty("public_flags")]
        public int PublicFlags { get; set; }
    }
}
