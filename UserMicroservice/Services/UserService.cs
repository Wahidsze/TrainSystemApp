using System.Security.Claims;
using UserMicroservice.Database;
using UserMicroservice.Models.ModelDatabase;
using UserMicroservice.Models.ModelViews;
using UserMicroservice.Repositories;

namespace UserMicroservice.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _users { get; set; }
        public UserService(ApplicationContext context) 
        {
            _users = new UserRepository(context);
        }
        public async Task<UserModel?> Login(LoginViewModel login)
        {
            var user = await _users.GetUserByEmailAndPassword(login.Email, login.Password);
            if (user != null) 
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel?> Register(RegisterViewModel login)
        {
            var user = await _users.GetUserByEmailAndPassword(login.Email, login.Password);
            if(user == null)
            {
                user = _users.CreateUserByEmailAndPassword(login.Email, login.Password);
                return user;
            }
            return null;
        }
    }
}
