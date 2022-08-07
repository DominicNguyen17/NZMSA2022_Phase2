using backend.Model;

namespace backend.Services
{
    public interface IUserServices
    {
        Task<User> GetUser(int id);
    }
}
