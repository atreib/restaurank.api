using System.Threading.Tasks;
using restaurank.api.Domain.Models;

namespace restaurank.api.Domain.UseCases
{
    public interface IAuthService
    {
        Task<UserModel> LoginAsync (string login, string password);
    }
}