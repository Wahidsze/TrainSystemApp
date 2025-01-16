using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApp.Models.ModelDatabase;

namespace WebApp.Repositories
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserByEmailAndPassword(String email, String password);
        public UserModel CreateUserByEmailAndPassword(String email, String password);
    }
}
