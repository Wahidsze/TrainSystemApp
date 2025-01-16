using TicketMicroservice.Models.ModelDatabase;

namespace TicketMicroservice.Repositories
{
    public interface ITicketRepository
    {
        public List<RouteModel> GetAllRoute();
        public WagonModel GetWagonById(Guid wagonId);
        public PlaceModel GetPlaceById(Guid placeId);
        public TicketModel GetTicketById(Guid ticketId);
        public UserTicketModel GetUserTicketById(Guid ticketId);
        public List<Condition> GetConditionsById(Guid wagonId);
        public DateModel GetDateById(Guid dateId);
        public RouteModel GetRouteById(Guid routeId);
		public TrainModel GetTrainById(Guid trainId);
		public IQueryable<IGrouping<Guid, WagonInfo>> GroupingPlacesByWagons(List<Guid> TicketsId);
        public IQueryable<TicketInfo> GroupingTicketsByTrain(DateTime DateStart, String PointStart, String PointEnd);
    }
}
    