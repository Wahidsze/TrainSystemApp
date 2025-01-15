using UserMicroservice.Services;
using UserMicroservice.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _service { get; set; }
        public TicketController(ITicketService service)
        {
            _service = service;
        }
        [HttpGet("get/{DateStart}/{PointStart}/{PointEnd}")]
        public IActionResult GetTicketsByDateAndPath(DateTime DateStart, String PointStart, String PointEnd)
        {
            var result = _service.GetTicketsByDateAndPath(DateStart, PointStart, PointEnd);
            var json = JsonSerializer.Serialize(result);
            return new OkObjectResult(json);
        }
    }
}
