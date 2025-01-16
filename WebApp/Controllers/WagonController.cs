using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketMicroservice.Models.ModelDatabase;
using WebApp.Models.ModelViews;
using WebApp.Services;
namespace WebApp.Controllers
{
	public class WagonController : Controller
	{
        private IBuyingMicroservice _service { get; set; }
        public WagonController(IBuyingMicroservice service)
        {
            _service = service;
        }
        [HttpGet]
		public IActionResult Index()
		{
            var sessionData = HttpContext.Session.GetString("SelectTicket");
            var ticket = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketViewModel>(sessionData);
            return View(ticket.Wagons);
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Buy(string selectPlace)
		{
			var place = JsonConvert.DeserializeObject<PlaceViewModel>(selectPlace);
            var userId = HttpContext.User.Claims.FirstOrDefault(t => t.Type != null).Value;
            var userTicket = await _service.BuyUserTicket(place.TicketId,Guid.Parse(userId));
			if (userTicket != null)
			{
				TempData["Message"] = "Действие выполнено успешно!";
			}
			else 
			{
                TempData["Message"] = "Произошла ошибка при покупке билета";
            }
            return RedirectToAction("Index", "Home");
        }
	}
}
