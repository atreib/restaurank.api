using System;

namespace restaurank.api.Domain.Models
{
    public class VoteModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int RestaurantId { get; set; }
        public RestaurantModel Restaurant { get; set; }

        public DateTime LunchDay { get; set; }
    }
}