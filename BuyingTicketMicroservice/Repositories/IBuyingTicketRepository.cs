using Microsoft.EntityFrameworkCore.ChangeTracking;
using BuyingTicketMicroservice.Models.ModelDatabase;

namespace BuyingTicketMicroservice.Repositories
{
    public interface IBuyingTicketRepository
    {
        public Task<UserTicketModel> AddUserTicket(Guid TicketId,Guid UserId);
    }
}
