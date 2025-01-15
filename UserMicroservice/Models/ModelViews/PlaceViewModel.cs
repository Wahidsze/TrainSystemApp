namespace UserMicroservice.Models.ModelViews
{
    public class PlaceViewModel
    {
        public String PlaceName { get; set; }
        public Guid TicketId { get; set; }
        public float Cost { get; set; }
        public bool IsOccupied{ get; set; }
    }
}
