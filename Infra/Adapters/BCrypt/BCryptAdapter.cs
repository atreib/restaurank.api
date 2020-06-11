using System;
using restaurank.api.Data.Protocols;

namespace restaurank.api.Infra.Adapters.BCryptAdapter
{
    public class BCryptAdapter : IEncrypter
    {
        private readonly string _salt;

        public BCryptAdapter () {
            _salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public string hash (string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value, _salt);
        }

        public bool compare (string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null) { throw new ArgumentNullException(nameof(hashedPassword)); }
            if (providedPassword == null) { throw new ArgumentNullException(nameof(providedPassword)); }
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
    }
}