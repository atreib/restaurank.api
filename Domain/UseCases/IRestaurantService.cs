using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using System.Collections.Generic;

namespace restaurank.api.Domain.UseCases
{
    public interface IRestaurantService
    {
         Task<IEnumerable<RestaurantModel>> GetAllAsync ();
    }
}