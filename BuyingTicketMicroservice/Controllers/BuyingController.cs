using System.Text.Json;
using BuyingTicketMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuyingTicketMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        private IBuyingService _service { get; set; }
        public BuyingController(IBuyingService service)
        {
            _service = service;
        }
        [HttpGet("buy/{TicketId}/{UserId}")]
        public async Task<IActionResult> AddUserTicket(Guid TicketId,Guid UserId)
        { 
            var result = await _service.AddUserTicket(TicketId,UserId);
            if (result != null)
            {
                var json = JsonSerializer.Serialize(result);
                return new OkObjectResult(json);
            }
            Console.WriteLine("1");
            return BadRequest(new { message = "Возникла ошибка при покупке билета"});
        }
    }
}
