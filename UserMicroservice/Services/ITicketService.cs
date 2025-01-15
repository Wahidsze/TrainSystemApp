using UserMicroservice.Models.ModelDatabase;
using UserMicroservice.Models.ModelViews;
namespace UserMicroservice.Services
{
    public interface ITicketService
    {
        public List<RouteModel> GetAllRoute();
        public List<TicketViewModel> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
