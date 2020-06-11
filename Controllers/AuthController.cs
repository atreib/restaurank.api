using System;
using Microsoft.AspNetCore.Mvc;
using restaurank.api.Domain.UseCases;
using System.Threading.Tasks;

namespace restaurank.api.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        public class LoginModel {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private readonly IAuthService _authService;

        public AuthController (IAuthService authService) {
            _authService = authService;
        }

        /// <summary>
        /// Autenticação por usuário e senha
        /// </summary>
        /// <returns>Objeto do usuário com a JWT para utilização</returns>
        /// <response code="200">Retorna o objeto do usuário com a JWT para utilização</response>
        /// <response code="400">Parâmetros enviados estão incorretos</response>
        /// <response code="422">Processamento encerrado, analise a mensagem retornada</response>
        /// <response code="500">Erro interno, entre em contato com o administrador</response>
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> LoginAsync ([FromBody]LoginModel loginData)
        {
            try {
                if (string.IsNullOrEmpty(loginData.Username))
                    throw new ArgumentNullException(nameof(loginData.Username));
                
                if (string.IsNullOrEmpty(loginData.Password))
                    throw new ArgumentNullException(nameof(loginData.Password));

                return Json(await _authService.LoginAsync(loginData.Username, loginData.Password));
            } 
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentException)
                    return BadRequest(ex);
                
                if (ex is ApplicationException)
                    return UnprocessableEntity(ex);

                return StatusCode(500, new Exception("Ops, tivemos um problema"));
            }
        }
    }
}