using System.Text.Json.Serialization;
using System.Collections.Generic;
using Bookings.Models;

namespace Login.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("booked flights")]
        public List<Flight> BookedFlights { get; set; }
    }
}
