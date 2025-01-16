using WebApp.Models.ModelViews;

namespace WebApp.Services
{
    public interface ITicketMicroservice
    {
        public Task<List<TicketViewModel>> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
