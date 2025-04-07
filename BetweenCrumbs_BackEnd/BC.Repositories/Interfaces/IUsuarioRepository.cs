using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<ResponseDto<UsuarioIngresoResponseDto>> InsertarUsuario(UsuarioRequestDto usuario);
        Task<ResponseDto<bool?>> VerificarCodigoUsuario(string usuario, string codigoVerificacion);
        Task<ResponseDto<bool?>> InsertarCodigoVerificacionForgot(string correoUsuario);
        Task<ResponseDto<bool?>> VerificarCodigoUsuarioForgot(string correoUsuario, string codigoVerificacion);
    }
}
