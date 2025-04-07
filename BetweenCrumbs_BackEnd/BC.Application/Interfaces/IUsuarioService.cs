using BC.Models.Dtos;
using BC.Models.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseDto<UsuarioIngresoResponseDto>> AgregarUsuario(UsuarioRequestDto usuario);
        Task<ResponseDto<bool?>> ValidarCodigoVerificacionUsuario(string usuario, string codigoVerificacion);
        Task<ResponseDto<bool?>> AgregarCodigoVerificacionForgot(string correoUsuario);
    }
}
