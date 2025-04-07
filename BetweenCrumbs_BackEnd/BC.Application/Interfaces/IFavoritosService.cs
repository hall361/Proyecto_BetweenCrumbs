using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Models.Dtos.Favoritos;

namespace BC.Application.Interfaces
{
    public interface IFavoritosService
    {
        Task<ResponseDto<bool?>> AgregarFavorito(FavoritosRequestDto favorito);
        Task<ResponseDto<bool?>> BorrarFavorito(string idUsuario, int idRecipe);
        Task<ResponseDto<List<FavoritosResponseDto>>> ObtenerFavoritos(string idUsuario);
    }
}
