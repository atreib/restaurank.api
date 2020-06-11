using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using restaurank.api.Data.Protocols;
using Microsoft.EntityFrameworkCore;

namespace restaurank.api.Infra.Db.SqlServer
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository (AppDbContext context) : base(context) { }

        public async Task<UserModel> LoginAsync (string login) {
            return await _context.Users
                .FirstOrDefaultAsync(r => r.Login == login);
        }
    }
}