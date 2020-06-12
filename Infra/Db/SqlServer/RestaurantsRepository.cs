using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using restaurank.api.Data.Protocols;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace restaurank.api.Infra.Db.SqlServer
{
    public class RestaurantsRepository : BaseRepository, IRestaurantsRepository
    {
        public RestaurantsRepository (AppDbContext context) : base(context) { }

        public async Task<IEnumerable<RestaurantModel>> GetAllAsync () {
            return await _context.Restaurants
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}