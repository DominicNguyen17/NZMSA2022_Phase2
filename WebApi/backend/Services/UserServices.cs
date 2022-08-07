using backend.Model;

namespace backend.Services
{
    public class UserServices : IUserServices
    {
        private readonly NZMSA2022_PokemonContext _context;

        public UserServices(NZMSA2022_PokemonContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
