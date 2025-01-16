using TicketMicroservice.Models.ModelDatabase;

namespace WebApp.Services
{
    public interface IBuyingMicroservice
    {
        public Task<UserTicketModel> BuyUserTicket(Guid TicketId, Guid UserId);
    }
}
