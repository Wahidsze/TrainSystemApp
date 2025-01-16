using System.Security.Claims;
using WebApp.Models.ModelViews;

namespace WebApp.Services

{
    public interface IUserMicroservice
    {
        public Task<ClaimsIdentity> Login(LoginViewModel model);
        public Task<ClaimsIdentity> Register(RegisterViewModel model);
    }
}
