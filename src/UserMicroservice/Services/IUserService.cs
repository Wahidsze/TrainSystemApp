using System.Security.Claims;
using UserMicroservice.Models.ModelViews;
using UserMicroservice.Models.ModelDatabase;

namespace UserMicroservice.Services
{
	public interface IUserService
	{
		public Task<UserModel?> Login(LoginViewModel login);
		public Task<UserModel?> Register(RegisterViewModel login);
	}
}
