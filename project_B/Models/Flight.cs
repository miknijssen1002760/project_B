using System.Text.Json.Serialization;

namespace project_B
{
    internal class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("planeID")]
        public int PlaneID { get; set; }

        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("departurePlace")]
        public string DeparturePlace { get; set; }

        [JsonIgnore]
        public string Secret { get; set; }

        public void writeToFile()
        {
            Flights flg = new Flights();
            flg.UpdateList(this);
        }
    }
}