using BuyingTicketMicroservice.Models.ModelDatabase;
using BuyingTicketMicroservice.Database;
using Microsoft.IdentityModel.Tokens;

namespace BuyingTicketMicroservice.Repositories
{
    public class BuyingTicketRepository : IBuyingTicketRepository
    {
        private IBaseRepository<UserTicketModel> _userTickets {  get; set; }
        public BuyingTicketRepository(ApplicationContext applicationContext) 
        {
            _userTickets = new BaseRepository<UserTicketModel>(applicationContext);
        }
        public async Task<UserTicketModel?> AddUserTicket(Guid TicketId, Guid UserId)
        {
            var userTicket = new UserTicketModel { Id = Guid.NewGuid() ,TicketId = TicketId, UserId = UserId, IsBuying = true };
            if (_userTickets.Where(u => u.TicketId == TicketId).IsNullOrEmpty())
            {
                Console.WriteLine(TicketId);
                return _userTickets.Create(new UserTicketModel { Id = Guid.NewGuid(), TicketId = TicketId, UserId = UserId, IsBuying = true }); ;
            }
            return null;
        }
    }
}
