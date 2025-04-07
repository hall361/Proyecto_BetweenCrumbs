using BC.Models.Dtos.Menu;
using BC.Models.Dtos;
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
using BC.Repositories.Utilities.Interfaces;
using BC.Repositories.Interfaces;

namespace BC.Repositories.Services
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ISecural _secural;
        public MenuRepository(IConfiguration configuration, ISecural secural)
        {
            _configuration = configuration;
            _secural = secural;
        }
        public async Task<ResponseDto<List<MenuResponseDto>>> SeleccionarMenuPorUsuario(string IdUsuario)
        {
            try
            {
                //var connection = new SqlConnection(secural.ConnectionKey(_configuration.GetConnectionString("Conexia")
                //var connection = new SqlConnection(_configuration.GetConnectionString("Conexia")
                using (var connection = new SqlConnection(_secural.ConnectionKey(_configuration.GetConnectionString("Conexia"))))
                {
                    string mensaje = "";
                    bool status = false;
                    List<MenuResponseDto> lista = new List<MenuResponseDto>();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@IdUsuario", value: IdUsuario, DbType.String, ParameterDirection.Input, size: 50);
                    parameters.Add("@Mensaje", value: mensaje, DbType.String, ParameterDirection.Output);
                    parameters.Add("@Status", value: status, DbType.Boolean, ParameterDirection.Output);

                    var result = await connection.QueryAsync<List<MenuResponseDto>>("BtcrSeleccionarMenuPorUsuario", parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        lista = (List<MenuResponseDto>)result;
                    }


                    mensaje = parameters.Get<string>("@Mensaje");
                    status = parameters.Get<bool>("@Status");
                    ResponseDto<List<MenuResponseDto>> response = new ResponseDto<List<MenuResponseDto>>(status, mensaje, lista);
                    return response;

                }
            }
            catch (Exception)
            {
                List<MenuResponseDto> lista = new List<MenuResponseDto>();
                ResponseDto<List<MenuResponseDto>> response = new ResponseDto<List<MenuResponseDto>>(false, "Ha ocurrido un error en seleccionar Menu", lista);
                return response;
            }
        }
    }
}
