using System.Threading.Tasks;
using restaurank.api.Domain.Models;

namespace restaurank.api.Domain.UseCases
{
    public interface IVoteService
    {
        Task<VoteModel> Vote (int UserId, int RestaurantId);
        Task<bool> GetDidUserAlreadyVotedAsync (int UserId);
        Task<RestaurantModel> GetTodayRestaurantAsync ();
    }
}