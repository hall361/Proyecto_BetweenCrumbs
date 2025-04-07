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

        [HttpPost("CrearUsuario")]
        public async Task<ActionResult<ResponseDto<UsuarioIngresoResponseDto>>> CrearUsuario([FromBody] UsuarioRequestDto usuarioIngreso)
        {
            return Ok(await _service.AgregarUsuario(usuarioIngreso));
        }

        [HttpPost("AgregarCodigoVerificacionForgot")]
        public async Task<ActionResult> AgregarCodigoVerificacionForgot([FromQuery] string correoUsuario)
        {
            return Ok( await _service.AgregarCodigoVerificacionForgot(correoUsuario));
        }

        [HttpPost("VerificarUsuario")]
        public async Task<ActionResult> VerificarUsuario([FromQuery] string usuario, string codigoVerificacion)
        {
            return Ok(await _service.ValidarCodigoVerificacionUsuario(usuario, codigoVerificacion));
        }

        [HttpPost("ValidarCodigoUsuarioForgot")]
        public async Task<ActionResult> ValidarCodigoUsuarioForgot([FromQuery] string correoUsuario, string codigoVerificacion)
        {
            return Ok(await _service.AgregarCodigoVerificacionForgot(correoUsuario));

        }

    }
}
