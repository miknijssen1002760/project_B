using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using project_B.Models;

namespace project_B.Models

{
    public class User
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("birthdate")]
        public string Birthday { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("IsAdmin")]
        public bool IsAdmin { get; set; }   
    }
}
