using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserMicroservice.Models.ModelDatabase;

namespace UserMicroservice.Repositories
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserByEmailAndPassword(String email, String password);
        public UserModel CreateUserByEmailAndPassword(String email, String password);
    }
}
