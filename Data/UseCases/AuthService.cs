using System.Threading.Tasks;
using System;
using restaurank.api.Domain.Models;
using restaurank.api.Domain.UseCases;
using restaurank.api.Data.Protocols;

namespace restaurank.api.Data.UseCases
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService (
            IUsersRepository usersRepository, 
            IEncrypter encrypter,
            IJwtGenerator jwtGenerator
        ) {
            _usersRepository = usersRepository;
            _jwtGenerator = jwtGenerator;
            _encrypter = encrypter;
        }

        public async Task<UserModel> LoginAsync (string login, string password)
        {
            var user = await _usersRepository.LoginAsync(login);
            if (user == null)
                throw new ApplicationException("Usuário incorreto");

            bool isPasswordCorrect = _encrypter.compare(user.Password, password);
            if (!isPasswordCorrect)
                throw new ApplicationException("Senha incorreta");

            user.Token = _jwtGenerator.GenerateJwt(login);
            return user;
        }
    }
}