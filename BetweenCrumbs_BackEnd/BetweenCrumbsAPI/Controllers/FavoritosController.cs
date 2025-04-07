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

        /// <summary>
        /// Crea un nuevo favorito para un usuario.
        /// </summary>
        /// <param name="favorito">Objeto con los datos del favorito a crear.</param>
        /// <returns>Un objeto ResponseDto indicando si la operación fue exitosa.</returns>
        [HttpPost("CrearFavorito")]
        public async Task<ActionResult<ResponseDto<bool?>>> CrearFavorito([FromBody] FavoritosRequestDto favorito)
        {
            return Ok(await _service.AgregarFavorito(favorito));
        }

        /// <summary>
        /// Obtiene la lista de favoritos de un usuario.
        /// </summary>
        /// <param name="IdUsuario">ID del usuario cuyos favoritos se desean obtener.</param>
        /// <returns>Una lista de objetos FavoritosResponseDto.</returns>
        [HttpGet("ObtenerFavoritos")]
        public async Task<ResponseDto<List<FavoritosResponseDto>>> ObtenerFavoritos([FromQuery] string IdUsuario)
        {
            ResponseDto<List<FavoritosResponseDto>> response = await _service.ObtenerFavoritos(IdUsuario);
            return response;
        }

        /// <summary>
        /// Elimina un favorito de un usuario.
        /// </summary>
        /// <param name="IdUsuario">ID del usuario.</param>
        /// <param name="IdRecipe">ID de la receta a eliminar de favoritos.</param>
        /// <returns>Un objeto indicando si la operación fue exitosa.</returns>
        [HttpDelete("BorrarFavorito")]
        public async Task<ActionResult> BorrarFavorito([FromQuery] string IdUsuario, int IdRecipe)
        {
            return Ok(await _service.BorrarFavorito(IdUsuario, IdRecipe));
        }
    }
}