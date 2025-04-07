using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BC.Models.Dtos.Usuario;
using BC.Application.Interfaces;
using BC.Models.Dtos;

namespace BetweenCrumbsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service) 
        {
            _service = service;
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuarioIngreso">Datos del usuario a registrar.</param>
        /// <returns>Un objeto ResponseDto con los datos del usuario creado.</returns>
        [HttpPost("CrearUsuario")]
        public async Task<ActionResult<ResponseDto<UsuarioIngresoResponseDto>>> CrearUsuario([FromBody] UsuarioRequestDto usuarioIngreso)
        {
            return Ok(await _service.AgregarUsuario(usuarioIngreso));
        }

        /// <summary>
        /// Agrega un código de verificación para recuperación de contraseña.
        /// </summary>
        /// <param name="correoUsuario">Correo del usuario.</param>
        /// <returns>Un objeto indicando si la operación fue exitosa.</returns>
        [HttpPost("AgregarCodigoVerificacionForgot")]
        public async Task<ActionResult> AgregarCodigoVerificacionForgot([FromQuery] string correoUsuario)
        {
            return Ok(await _service.AgregarCodigoVerificacionForgot(correoUsuario));
        }

        /// <summary>
        /// Verifica un usuario mediante un código de verificación.
        /// </summary>
        /// <param name="usuario">Nombre del usuario.</param>
        /// <param name="codigoVerificacion">Código de verificación.</param>
        /// <returns>Un objeto indicando si la operación fue exitosa.</returns>
        [HttpPost("VerificarUsuario")]
        public async Task<ActionResult> VerificarUsuario([FromQuery] string usuario, string codigoVerificacion)
        {
            return Ok(await _service.ValidarCodigoVerificacionUsuario(usuario, codigoVerificacion));
        }

        /// <summary>
        /// Valida un código de verificación para recuperación de contraseña.
        /// </summary>
        /// <param name="correoUsuario">Correo del usuario.</param>
        /// <param name="codigoVerificacion">Código de verificación.</param>
        /// <returns>Un objeto indicando si la operación fue exitosa.</returns>
        [HttpPost("ValidarCodigoUsuarioForgot")]
        public async Task<ActionResult> ValidarCodigoUsuarioForgot([FromQuery] string correoUsuario, string codigoVerificacion)
        {
            return Ok(await _service.AgregarCodigoVerificacionForgot(correoUsuario));
        }
    }
}