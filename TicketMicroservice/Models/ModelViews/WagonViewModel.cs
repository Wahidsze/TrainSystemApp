﻿using TicketMicroservice.Models.ModelDatabase;

namespace TicketMicroservice.Models.ModelViews
{
    public class WagonViewModel
    {
        public String WagonName { get; set; }
        public String WagonType { get; set; }
        public List<Condition> WagonConditions { get; set; }
        public List<PlaceViewModel> WagonPlacements { get; set; }
    }
}
