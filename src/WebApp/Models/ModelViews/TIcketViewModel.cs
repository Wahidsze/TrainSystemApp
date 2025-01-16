using Newtonsoft.Json;

namespace WebApp.Models.ModelViews
{
    public class TicketViewModel
    {
        [JsonProperty("trainName")]
        public String TrainName { get; set; }

        [JsonProperty("trainType")]
        public String TrainType { get; set; }

        [JsonProperty("wagons")]
        public List<WagonViewModel> Wagons { get; set; }

        [JsonProperty("dateStart")]
        public DateTime DateStart { get; set; }

        [JsonProperty("dateEnd")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("pointStart")]
        public String PointStart { get; set; }

        [JsonProperty("pointEnd")]
        public String PointEnd { get; set; }

    }
}
