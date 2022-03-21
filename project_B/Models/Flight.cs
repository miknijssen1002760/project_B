using System.Text.Json.Serialization;

namespace project_B.Models
{
    internal class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("planeID")]
        public int planeID { get; set; }

        [JsonPropertyName("seatOcc")]
        public string seatOcc { get; set; }

        [JsonPropertyName("date")]
        public int date { get; set; }

        [JsonPropertyName("duratoin")]
        public int duratoin { get; set; }

        [JsonPropertyName("destination")]
        public string destination { get; set; }

        [JsonPropertyName("departurePlace")]
        public string departurePlace { get; set; }

        [JsonIgnore]
        public string Secret { get; set; }

        public void writeToFile()
        {
            Flights acc = new Flights();
            acc.UpdateList(this);
        }
    }
}