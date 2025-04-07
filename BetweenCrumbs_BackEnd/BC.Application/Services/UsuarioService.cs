using BC.Application.Interfaces;
using BC.Models.Dtos;
using BC.Models.Dtos.Usuario;
using BC.Repositories.Interfaces;
using BC.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<ResponseDto<UsuarioIngresoResponseDto>> AgregarUsuario(UsuarioRequestDto usuario)
        {
            ResponseDto<UsuarioIngresoResponseDto> response = await _repo.InsertarUsuario(usuario);
            return response;
        }

        public async Task<ResponseDto<bool?>> ValidarCodigoVerificacionUsuario(string usuario, string codigoVerificacion)
        {
            ResponseDto<bool?> response = await _repo.VerificarCodigoUsuario(usuario,codigoVerificacion);
            return response;
        }

        public async Task <ResponseDto<bool?>> AgregarCodigoVerificacionForgot(string correoUsuario)
        {
            ResponseDto<bool?> response = await _repo.InsertarCodigoVerificacionForgot(correoUsuario);
            return response;
        }

        public async Task<ResponseDto<bool?>> ValidarCodigoUsuarioForgot(string correoUsuario, string codigoVerificacion)
        {
            ResponseDto<bool?> response = await _repo.VerificarCodigoUsuarioForgot(correoUsuario, codigoVerificacion);
            return response;
        }

    }
}
