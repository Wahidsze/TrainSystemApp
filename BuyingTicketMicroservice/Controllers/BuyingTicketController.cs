using System.Text.Json;
using BuyingTicketMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyingTicketMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingTicketController : ControllerBase
    {
        private IBuyingTicketService _service { get; set; }
        public BuyingTicketController(IBuyingTicketService service)
        {
            _service = service;
        }
        [HttpGet("buy/{TicketId}/{UserId}")]
        public IActionResult AddUserTicket(Guid TicketId,Guid UserId)
        { 
            var result = _service.AddUserTicket(TicketId,UserId);
            if (result != null)
            {
                var json = JsonSerializer.Serialize(result);
                return new OkObjectResult(json);
            }
            return BadRequest(new { message = "Возникла ошибка при покупке билета"});
        }
    }
}
