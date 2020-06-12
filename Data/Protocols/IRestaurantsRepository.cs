using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using System.Collections.Generic;

namespace restaurank.api.Data.Protocols
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<RestaurantModel>> GetAllAsync ();
    }
}