using System.Text.Json.Serialization;
using project_B.Controllers;

namespace project_B.Models
{
    public class plane
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("planeID")]
        public int PlaneID { get; set; }

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

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