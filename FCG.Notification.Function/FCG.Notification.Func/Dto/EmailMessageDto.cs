using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FCG.Notification.Func.Dto
{
    public class EmailMessageDto
    {
        [JsonPropertyName("to")]
        public string To { get; set; } = default!;

        [JsonPropertyName("subject")]
        public string Subject { get; set; } = default!;

        [JsonPropertyName("body")]
        public string Body { get; set; } = default!;
    }
}
