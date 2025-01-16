using UserMicroservice.Services;
using UserMicroservice.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service { get; set; }
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Login(model);
                if (result != null)
                {
                    var json = JsonSerializer.Serialize(result);
                    return Ok(json);
                }
                return Unauthorized(new { message = "Некорректные логин и(или) пароль" });
            }
            return BadRequest(new { message = "Некорректно введены данные", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Register(model);
                if (result != null)
                {
                    var json = JsonSerializer.Serialize(result);
                    return Ok(json);
                }
                return BadRequest(new { message = "Не удалось зарегистрироваться" });
            }
            return BadRequest(new { message = "Некорректно введены данные", errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }
    }
}
