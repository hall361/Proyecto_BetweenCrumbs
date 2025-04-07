using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Models.Dtos.Favoritos;

namespace BC.Repositories.Interfaces
{
    public interface IFavoritosRepository
    {
        Task<ResponseDto<bool?>> EliminarFavorito(string idUsuario, int idRecipe);
        Task<ResponseDto<bool?>> InsertarFavorito(FavoritosRequestDto favorito);
        Task<ResponseDto<List<FavoritosResponseDto>>> SeleccionarFavoritos(string idUsuario);
    }
}
