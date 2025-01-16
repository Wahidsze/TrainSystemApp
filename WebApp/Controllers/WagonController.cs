using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ModelViews;

namespace WebApp.Controllers
{
	public class WagonController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
            var sessionData = HttpContext.Session.GetString("SelectTicket");
            var ticket = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketViewModel>(sessionData);
            return View(ticket.Wagons);
		}
		[HttpPost]
		public IActionResult Index(string selectPlace)
		{
            HttpContext.Session.SetString("SelectPlace", selectPlace);
            return Content(selectPlace);
		}
	}
}
