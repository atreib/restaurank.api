using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using restaurank.api.Data.Protocols;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace restaurank.api.Infra.Db.SqlServer
{
    public class VotesRepository : BaseRepository, IVotesRepository
    {
        public VotesRepository (AppDbContext context) : base(context) { }

        public async Task<VoteModel> Vote (VoteModel vote) {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync(true);
            return vote;
        }

        public async Task<bool> GetDidUserAlreadyVotedAsync (int UserId) {
            var exists = await _context.Votes
                .FirstOrDefaultAsync(x => x.UserId == UserId 
                    && x.LunchDay.Date == System.DateTime.Now.AddDays(1).Date);
            return (exists != null);
        }

        public async Task<RestaurantModel> GetTodayRestaurantAsync () {
            var result = await _context.Votes
                .Where(x => x.LunchDay.Date == System.DateTime.Now.Date)
                .GroupBy(n => n.RestaurantId)
                .Select(n => new
                    {
                        RestaurantId = n.Key,
                        Votes = n.Count()
                    }
                )
                .OrderByDescending(n => n.Votes)
                .FirstOrDefaultAsync();

            if (result != null) {
                var choosenRestaurant = await _context.Restaurants
                    .FirstOrDefaultAsync(x => x.Id == result.RestaurantId);
                return choosenRestaurant;
            } else {
                return null;
            }
        }

    }
}