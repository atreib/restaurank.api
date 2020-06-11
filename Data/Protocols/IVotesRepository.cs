using System.Threading.Tasks;
using restaurank.api.Domain.Models;

namespace restaurank.api.Data.Protocols
{
    public interface IVotesRepository
    {
        Task<VoteModel> Vote (VoteModel vote);
        Task<bool> GetDidUserAlreadyVotedAsync (int UserId);
        Task<RestaurantModel> GetTodayRestaurantAsync ();
    }
}