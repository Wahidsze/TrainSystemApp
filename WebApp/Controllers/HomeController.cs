using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrainSystem.Models.ModelViews;
using TrainSystem.Services;

namespace TrainSystem.Controllers
{
    public class HomeController : Controller
    {
    
        private ITicketMicroservice _service {  get; set; }
        public HomeController(ITicketMicroservice service) 
        {
			_service = service;
		}
        public IActionResult Index()
        {
            return RedirectToAction("Input", "Home");
        }
        [HttpGet]
        public IActionResult Input() 
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Input(InputViewModel input)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.GetTicketsByDateAndPath(input.DateStart, input.PointStart, input.PointEnd);
                if (!result.IsNullOrEmpty())
                {
                    HttpContext.Session.SetString("Tickets", Newtonsoft.Json.JsonConvert.SerializeObject(result));
                    return RedirectToAction("Index", "Ticket");
                }
                ModelState.AddModelError("", "Нет билетов в соотвествии с введенными данными!");

            }
            return View(input);
            
        }
    }
}
