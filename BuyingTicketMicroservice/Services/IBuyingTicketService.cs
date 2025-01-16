using System.Security.Claims;
using BuyingTicketMicroservice.Models.ModelViews;
using BuyingTicketMicroservice.Models.ModelDatabase;

namespace BuyingTicketMicroservice.Services
{
	public interface IBuyingTicketService
	{
        public Task<UserTicketModel> AddUserTicket(Guid TicketId, Guid UserId);
    }
}
