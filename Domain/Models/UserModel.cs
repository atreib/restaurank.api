using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurank.api.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}