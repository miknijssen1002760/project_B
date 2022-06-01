using System.Text.Json.Serialization;

namespace project_B.Models
{
    internal class plane
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("planeID")]
        public int PlaneID { get; set; }

        [JsonPropertyName("layout")]
        public string[][] Layout { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }


        [JsonIgnore]
        public string Secret { get; set; }

        public void writeToFile()
        {
            planes pln = new planes();
            pln.UpdateList(this);
        }
    }
}