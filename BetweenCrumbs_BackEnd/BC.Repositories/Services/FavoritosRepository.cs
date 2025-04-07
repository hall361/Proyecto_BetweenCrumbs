using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using BC.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BC.Repositories.Utilities.Services.Secural;
using BC.Models.Dtos.Favoritos;
using BC.Repositories.Utilities.Interfaces;
using BC.Models.Dtos.Menu;

namespace BC.Repositories.Services
{
    public class FavoritosRepository : IFavoritosRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ISecural _secural;
        public FavoritosRepository(IConfiguration configuration, ISecural secural)
        {
            _configuration = configuration;
            _secural = secural;
        }
        public async Task<ResponseDto<bool?>> InsertarFavorito(FavoritosRequestDto favorito)
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
                    parameters.Add("@IdRecipe", value: favorito.IdRecipe, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@NombreRecipe", value: favorito.NombreRecipe, DbType.String, ParameterDirection.Input, size: 1000);
                    parameters.Add("@IdUsuario", value: favorito.IdUsuario, DbType.String, ParameterDirection.Input, size: 50);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);

                    var result = await connection.ExecuteAsync("BtcrInsertarFavorito", parameters, commandType: CommandType.StoredProcedure);
                    
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    idUsuario = parameters.Get<string>("@IdUsuario");
                    UsuarioIngresoResponseDto usuarioResponse = new UsuarioIngresoResponseDto
                    {
                        IdUsuario = idUsuario
                    };

                    ResponseDto<bool?> response = new ResponseDto<bool?>(true, mensaje);
                    return response;

                }
            }
            catch (Exception)
            {
                ResponseDto<bool?> response = new ResponseDto<bool?>(false, "Ha ocurrido un error en la insercion de receta a favoritos");
                return response;
            }
        }

        public async Task<ResponseDto<List<FavoritosResponseDto>>> SeleccionarFavoritos(string idUsuario)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia")
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;
                    List<FavoritosResponseDto> lista = new List<FavoritosResponseDto>();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IdUsuario", value: idUsuario, DbType.String, ParameterDirection.Input, size: 50);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);

                    var result = await connection.QueryAsync<FavoritosResponseDto>("BtcrSeleccionarFavoritos", parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        lista = result.ToList();
                    }


                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    ResponseDto<List<FavoritosResponseDto>> response = new ResponseDto<List<FavoritosResponseDto>>(status, mensaje, lista);
                    return response;

                }
            }
            catch (Exception)
            {
                ResponseDto<List<FavoritosResponseDto>> response = new ResponseDto<List<FavoritosResponseDto>>(false, "Ha ocurrido un error en seleccionar favoritos");
                return response;
            }
        }

        public async Task<ResponseDto<bool?>> EliminarFavorito(string idUsuario, int idRecipe)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia"))
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IdUsuario", value: idUsuario, DbType.String, ParameterDirection.Input, size: 50);
                    parameters.Add("@IdRecipe", value: idRecipe, DbType.String, ParameterDirection.Input, size: 6);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);
                    

                    var result = await connection.ExecuteAsync("BtcrEliminarFavorito", parameters, commandType: CommandType.StoredProcedure);
                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");

                    ResponseDto<bool?> response = new ResponseDto<bool?>(true, mensaje);
                    return response;

                }
            }
            catch (Exception)
            {
                ResponseDto<bool?> response = new ResponseDto<bool?>(false, "Ha ocurrido un error en el borrado de la receta");
                return response;
            }
        }
    }
}
