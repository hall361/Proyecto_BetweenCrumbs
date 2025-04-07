using BC.Repositories.Interfaces;
using System.Data;
using BC.Models.Dtos;
using BC.Models.Dtos.Usuario;
using Dapper;
using System.Data.SqlClient;
using static BC.Repositories.Utilities.Services.Secural;
using Microsoft.Extensions.Configuration;
using BC.Models.Dtos.Menu;
using System.Linq;
using BC.Repositories.Utilities.Interfaces;

namespace BC.Repositories.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ISecural _secural;
        public UsuarioRepository(IConfiguration configuration, ISecural secural)
        { 
            _configuration = configuration;
            _secural = secural;
        }

        public async Task<ResponseDto<UsuarioIngresoResponseDto>> InsertarUsuario(UsuarioRequestDto usuario)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia"))
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;
                    string idUsuario = "";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@NombreUsuario", value: usuario.NombreUsuario,  DbType.String, ParameterDirection.Input, size: 200);
                    parameters.Add("@CorreoElectronico", value: usuario.CorreoElectronico, DbType.String, ParameterDirection.Input, size: 200);
                    parameters.Add("@Contrasena", value: usuario.Contrasena, DbType.String, ParameterDirection.Input, size: 1000);
                    //parameters.Add("@Contrasena", value: secural.CreateKey(usuario.Contrasena), DbType.String, ParameterDirection.Input, size: 1000);
                    parameters.Add("@Mensaje", value:mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);
                    parameters.Add("@IdUsuario", value: idUsuario, DbType.String, ParameterDirection.Output);

                    var result = await connection.ExecuteAsync("BtcrInsertarUsuario", parameters, commandType: CommandType.StoredProcedure);
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    idUsuario = parameters.Get<string>("@IdUsuario");
                    UsuarioIngresoResponseDto usuarioResponse = new UsuarioIngresoResponseDto
                    {
                        IdUsuario = idUsuario
                    };

                    ResponseDto<UsuarioIngresoResponseDto> response = new ResponseDto<UsuarioIngresoResponseDto>(true, mensaje, usuarioResponse);
                    return response;

                }
            }
            catch (Exception ex)
            {
                object obj = new object();
                ResponseDto<UsuarioIngresoResponseDto> response = new ResponseDto<UsuarioIngresoResponseDto>(false, ex.Message, new UsuarioIngresoResponseDto { IdUsuario = "0"});
                return response;
            }
        }

        public async Task<ResponseDto<bool?>> VerificarCodigoUsuario(string usuario, string codigoVerificacion)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia")
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IdUsuario", value: usuario, DbType.String, ParameterDirection.Input, size: 50);
                    parameters.Add("@CodigoVerificacion", value: codigoVerificacion, DbType.String, ParameterDirection.Input, size: 6);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);

                    var result = await connection.ExecuteAsync("BtcrVerificarUsuario", parameters, commandType: CommandType.StoredProcedure);
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    ResponseDto<bool?> response = new ResponseDto<bool?>(status, mensaje);
                    return response;

                }
            }
            catch (Exception ex)
            {
                object obj = new object();
                ResponseDto<bool?> response = new ResponseDto<bool?>(false, "Ha ocurrido un error. " + ex.Message, false);
                return response;
            }
        }
        
        public async Task<ResponseDto<bool?>> InsertarCodigoVerificacionForgot(string correoUsuario)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia")
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CorreoUsuario", value: correoUsuario, DbType.String, ParameterDirection.Input, size: 200);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);


                    var result = await connection.ExecuteAsync("BtcrInsertarCodVerifForgot", parameters, commandType: CommandType.StoredProcedure);
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    ResponseDto<bool?> response = new ResponseDto<bool?>(status, mensaje);
                    return response;

                }
            }
            catch (Exception ex)
            {
                object obj = new object();
                ResponseDto<bool?> response = new ResponseDto<bool?>(false, "Ha ocurrido un error. " + ex.Message, false);
                return response;
            }
        }
        public async Task<ResponseDto<bool?>> VerificarCodigoUsuarioForgot(string correoUsuario, string codigoVerificacion)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia")
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CorreoUsuario", value: correoUsuario, DbType.String, ParameterDirection.Input, size: 200);
                    parameters.Add("@CodigoVerificacion", value: codigoVerificacion, DbType.String, ParameterDirection.Input, size: 6);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);

                    var result = await connection.ExecuteAsync("BtcrVerificarUsuarioForgot", parameters, commandType: CommandType.StoredProcedure);
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    ResponseDto<bool?> response = new ResponseDto<bool?>(status, mensaje);
                    return response;

                }
            }
            catch (Exception ex)

            {
                object obj = new object();
                ResponseDto<bool?> response = new ResponseDto<bool?>(false, "Ha ocurrido un error. " + ex.Message, false);
                return response;
            }
        }
    }
}
