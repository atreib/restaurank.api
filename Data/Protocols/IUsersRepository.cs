using System.Threading.Tasks;
using restaurank.api.Domain.Models;

namespace restaurank.api.Data.Protocols
{
    public interface IUsersRepository
    {
        Task<UserModel> LoginAsync (string login);
    }
}