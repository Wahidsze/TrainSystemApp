using TrainSystem.Models.ModelViews;

namespace TrainSystem.Services
{
    public interface ITicketMicroservice
    {
        public Task<List<TicketViewModel>> GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd);
    }
}
