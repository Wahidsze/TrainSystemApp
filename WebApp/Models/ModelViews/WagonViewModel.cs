using Newtonsoft.Json;
using TrainSystem.Models.ModelDatabase;

namespace TrainSystem.Models.ModelViews
{
    public class WagonViewModel
    {
        [JsonProperty("wagonName")]
        public String WagonName { get; set; }

        [JsonProperty("wagonType")]
        public String WagonType { get; set; }

        [JsonProperty("wagonConditions")]
        public List<Condition> WagonConditions { get; set; }

        [JsonProperty("wagonPlacements")]
        public List<PlaceViewModel> WagonPlacements { get; set; }
    }
}
