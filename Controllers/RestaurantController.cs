using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using restaurank.api.Domain.UseCases;
using System.Threading.Tasks;

namespace restaurank.api.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController (IRestaurantService restaurantService) {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Listagem de todos os restaurantes cadastrados
        /// </summary>
        /// <returns>Array do model dos restaurantes cadastrados</returns>
        /// <response code="200">Array do model dos restaurantes cadastrados</response>
        /// <response code="401">Não foi enviado o JWT no Header</response>
        /// <response code="500">Erro interno, entre em contato com o administrador</response>
        [Route("")]
        [HttpGet]
        public async Task<ActionResult> GetTodayRestaurantAsync ()
        {
            try {
                return Json(await _restaurantService.GetAllAsync());
            } 
            catch
            {
                return StatusCode(500, new Exception("Ops, tivemos um problema"));
            }
        }
    }
}