using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nexus.Models
{
    public class Account
    {
        [JsonPropertyName("displayUsername")]
        public string DisplayUsername { get; set; }

        [JsonPropertyName("defaultToken")]
        public string DefaultToken { get; set; }

        [JsonPropertyName("tokens")]
        public List<string> Tokens { get; set; }
    }
}
