using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotInteractions.Models
{
    internal class InteractionResponse
    {
        public InteractionCallbackType Type { get; set; }
        public InteractionCallbackData Data { get; set; }
    }
}
