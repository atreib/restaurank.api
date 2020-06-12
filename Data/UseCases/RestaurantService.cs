using System.Threading.Tasks;
using restaurank.api.Domain.Models;
using System.Collections.Generic;
using restaurank.api.Domain.UseCases;
using restaurank.api.Data.Protocols;

namespace restaurank.api.Data.UseCases
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantsRepository _restaurantsRepository;

        public RestaurantService (IRestaurantsRepository restaurantsRepository) {
            _restaurantsRepository = restaurantsRepository;
        }
        public async Task<IEnumerable<RestaurantModel>> GetAllAsync () {
            return await _restaurantsRepository.GetAllAsync();
        }
    }
}