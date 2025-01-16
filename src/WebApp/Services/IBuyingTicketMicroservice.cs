using TicketMicroservice.Models.ModelDatabase;

namespace WebApp.Services
{
    public interface IBuyingTicketMicroservice
    {
        public Task<UserTicketModel> BuyUserTicket(Guid TicketId, Guid UserId);
    }
}
