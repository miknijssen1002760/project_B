using System.Text.Json.Serialization;
using System.Collections.Generic;
using project_B.Models;

namespace project_B.Models

{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
