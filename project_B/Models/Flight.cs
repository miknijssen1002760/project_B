using System.Text.Json.Serialization;
using project_B.Controllers;

namespace project_B.Models
{
    public class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("planeID")]
        public int PlaneID { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("departurePlace")]
        public string DeparturePlace { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonIgnore]
        public string Secret { get; set; }

        public void writeToFile()
        {
            Flights flg = new Flights();
            flg.UpdateList(this);
        }
    }
}