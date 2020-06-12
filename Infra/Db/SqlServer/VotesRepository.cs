using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using restaurank.api.Data.Protocols;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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

            // get today results
            var results = await _context.Votes
                .Where(x => x.LunchDay.Date == System.DateTime.Now.Date)
                .GroupBy(n => n.RestaurantId)
                .Select(n => new
                    {
                        RestaurantId = n.Key,
                        Votes = n.Count()
                    }
                )
                .OrderByDescending(n => n.Votes)
                .ToListAsync();

            // get this week winners
            int diffToSunday = 0;
            System.DayOfWeek weekDay = System.DateTime.Now.DayOfWeek;
            switch (weekDay) {
                case System.DayOfWeek.Monday: diffToSunday = 1; break;
                case System.DayOfWeek.Thursday: diffToSunday = 2; break;
                case System.DayOfWeek.Wednesday: diffToSunday = 3; break;
                case System.DayOfWeek.Tuesday: diffToSunday = 4; break;
                case System.DayOfWeek.Friday: diffToSunday = 5; break;
                case System.DayOfWeek.Saturday: diffToSunday = 6; break;
            }
            System.DateTime startPeriod = System.DateTime.Now.AddDays(-1 * diffToSunday).Date;
            System.DateTime endPeriod = System.DateTime.Now.AddDays(-1).Date;
            var thisWeekWinners = await _context.Votes
                .Where(x => x.LunchDay.Date >= startPeriod.Date && x.LunchDay.Date <= endPeriod.Date)
                .GroupBy(n => new { 
                    LunchDay = n.LunchDay.Date, 
                    RestaurantId = n.RestaurantId 
                })
                .Select(n => new
                    {
                        LunchDay = n.Key.LunchDay,
                        RestaurantId = n.Key.RestaurantId,
                        Votes = n.Count()
                    }
                )
                .GroupBy(n => n.LunchDay.Date)
                .Select(g => 
                    g.OrderByDescending(p => p.Votes)
                        .FirstOrDefault()
                )
                .ToListAsync();

            // getting the most votes that hasnt win yet
            int startIndex = 0;
            int? winnerRestaurant = null;
            bool alreadyWon = false;
            do {
                winnerRestaurant = results[startIndex].RestaurantId;
                alreadyWon = thisWeekWinners.Find(o => o.RestaurantId == winnerRestaurant) != null;
                startIndex++;
            } while (alreadyWon && startIndex < results.Count);
            if (alreadyWon) winnerRestaurant = null;

            // returning today winner
            if (winnerRestaurant != null) {
                var choosenRestaurant = await _context.Restaurants
                    .FirstOrDefaultAsync(x => x.Id == winnerRestaurant);
                return choosenRestaurant;
            } else {
                return null;
            }
        }

    }
}