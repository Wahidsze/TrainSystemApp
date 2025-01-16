using System.Security.Claims;
using BuyingTicketMicroservice.Database;
using BuyingTicketMicroservice.Models.ModelDatabase;
using BuyingTicketMicroservice.Models.ModelViews;
using BuyingTicketMicroservice.Repositories;

namespace BuyingTicketMicroservice.Services
{
    public class BuyingService : IBuyingService
    {
        private IBuyingTicketRepository _userTickets { get; set; }
        public BuyingService(ApplicationContext context) 
        {
            _userTickets = new BuyingTicketRepository(context);
        }
        public async Task<UserTicketModel> AddUserTicket(Guid TicketId,Guid UserId)
        {
            return await _userTickets.AddUserTicket(TicketId, UserId);
        }
    }
}
