using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using restaurank.api.Domain.UseCases;
using System.Threading.Tasks;

namespace restaurank.api.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class VoteController : Controller
    {
        public class AddVoteModel {
            public int UserId { get; set; }
            public int RestaurantId { get; set; }
        }

        private readonly IVoteService _voteService;

        public VoteController (IVoteService voteService) {
            _voteService = voteService;
        }

        /// <summary>
        /// Declarar voto de um usuário em um restaurante para amanhã
        /// </summary>
        /// <returns>Sem retorno</returns>
        /// <response code="200">Sucesso ao realizar o voto</response>
        /// <response code="400">Parâmetros enviados estão incorretos</response>
        /// <response code="401">Não foi enviado o JWT no Header</response>
        /// <response code="500">Erro interno, entre em contato com o administrador</response>
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Vote ([FromBody]AddVoteModel voteData)
        {
            try {
                if (string.IsNullOrEmpty(voteData.UserId.ToString()))
                    throw new ArgumentNullException(nameof(voteData.UserId));
                
                if (string.IsNullOrEmpty(voteData.RestaurantId.ToString()))
                    throw new ArgumentNullException(nameof(voteData.RestaurantId));

                var voteResult = await _voteService.Vote(voteData.UserId, voteData.RestaurantId);
                return Ok();
            } 
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentException)
                    return BadRequest(ex);

                return StatusCode(500, new Exception("Ops, tivemos um problema"));
            }
        }

        /// <summary>
        /// Verificar se um usuário já votou para o próximo restaurante
        /// </summary>
        /// <returns>Booleano informando se o usuário já votou (true) ou não (false)</returns>
        /// <response code="200">Booleano informando se o usuário já votou ou não</response>
        /// <response code="400">ID do usuário não foi informado</response>
        /// <response code="401">Não foi enviado o JWT no Header</response>
        /// <response code="500">Erro interno, entre em contato com o administrador</response>
        [Route("participated/user/{id:int}")]
        [HttpGet]
        public async Task<ActionResult> GetDidUserAlreadyVotedAsync (int id)
        {
            try {
                if (string.IsNullOrEmpty(id.ToString()))
                    throw new ArgumentNullException("ID do usuário");

                return Json(await _voteService.GetDidUserAlreadyVotedAsync(id));
            } 
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentException)
                    return BadRequest(ex);
                
                return StatusCode(500, new Exception("Ops, tivemos um problema"));
            }
        }

        /// <summary>
        /// Consulta qual o restaurante escolhido para hoje
        /// </summary>
        /// <returns>Model do restaurante escolhido para hoje</returns>
        /// <response code="200">Model do restaurante escolhido para hoje</response>
        /// <response code="401">Não foi enviado o JWT no Header</response>
        /// <response code="500">Erro interno, entre em contato com o administrador</response>
        [Route("winner")]
        [HttpGet]
        public async Task<ActionResult> GetTodayRestaurantAsync ()
        {
            try {
                return Json(await _voteService.GetTodayRestaurantAsync());
            } 
            catch
            {
                return StatusCode(500, new Exception("Ops, tivemos um problema"));
            }
        }
    }
}