using System.Threading.Tasks;
using System;
using restaurank.api.Domain.Models;
using restaurank.api.Domain.UseCases;
using restaurank.api.Data.Protocols;

namespace restaurank.api.Data.UseCases
{
    public class VoteService : IVoteService
    {
        private readonly IVotesRepository _votesRepository;

        public VoteService (IVotesRepository votesRepository) {
            _votesRepository = votesRepository;
        }

        public async Task<VoteModel> Vote (int userId, int restaurantId) {
            return await _votesRepository.Vote(new VoteModel {
                UserId = userId,
                RestaurantId = restaurantId,
                LunchDay = DateTime.Now.AddDays(1)
            });
        }

        public async Task<bool> GetDidUserAlreadyVotedAsync (int userId) {
            return await _votesRepository.GetDidUserAlreadyVotedAsync(userId);
        }

        public async Task<RestaurantModel> GetTodayRestaurantAsync () {
            return await _votesRepository.GetTodayRestaurantAsync();
        }
    }
}