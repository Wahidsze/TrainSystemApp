using TicketMicroservice.Models.ModelDatabase;
using TicketMicroservice.Models.ModelViews;
namespace TicketMicroservice.Services
{
    public interface ITicketService
    {
        public List<RouteModel> GetAllRoute();
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
