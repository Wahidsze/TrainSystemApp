using WebApp.Models.ModelViews;
using System.Text;
using System.Security.Claims;
using Newtonsoft.Json;
using UserMicroservice.Models.ModelDatabase;

namespace WebApp.Services
{
    public class UserMicroserviceImpl : IUserMicroservice
    {
        private HttpClient _httpClient { get; set; }
        public UserMicroserviceImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ClaimsIdentity?> Login(LoginViewModel loginViewModel)
        {
            var options = $"api/user/login";
            var jsonContent = JsonConvert.SerializeObject(loginViewModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(options,content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(json); 
                return CreateClaimsIndentity(user);
            }
            return null;

        }
        public async Task<ClaimsIdentity?> Register(RegisterViewModel registerViewModel)
        {
            var options = $"api/user/register";
            var jsonContent = JsonConvert.SerializeObject(registerViewModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(options, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(json);
                return CreateClaimsIndentity(user);
            }
            return null;
        }
        private ClaimsIdentity CreateClaimsIndentity(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                new Claim(ClaimTypes.Email, user.Email), 
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
