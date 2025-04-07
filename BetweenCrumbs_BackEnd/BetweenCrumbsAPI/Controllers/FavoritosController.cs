using BC.Application.Interfaces;
using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using BC.Models.Dtos.Favoritos;
using BC.Models.Dtos.Menu;

namespace BetweenCrumbsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly IFavoritosService _service;

        public FavoritosController(IFavoritosService service)
        {
            _service = service;
        }

        [HttpPost("CrearFavorito")]
        public async Task<ActionResult<ResponseDto<bool?>>> CrearFavorito([FromBody] FavoritosRequestDto favorito)
        {
            return Ok(await _service.AgregarFavorito(favorito));
        }

        [HttpGet("ObtenerFavoritos")]
        public async Task<ResponseDto<List<FavoritosResponseDto>>> ObtenerFavoritos([FromQuery] string IdUsuario)
        {
            ResponseDto<List<FavoritosResponseDto>> response = await _service.ObtenerFavoritos(IdUsuario);
            return response;
        }

        [HttpDelete("BorrarFavorito")]
        public async Task<ActionResult> BorrarFavorito([FromQuery] string IdUsuario, int IdRecipe)
        {
            return Ok(await _service.BorrarFavorito(IdUsuario, IdRecipe));
        }

    }
}
