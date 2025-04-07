using BC.Application.Interfaces;
using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using BC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Models.Dtos.Favoritos;

namespace BC.Application.Services
{
    public class FavoritosService : IFavoritosService
    {
        private readonly IFavoritosRepository _repository;

        public FavoritosService(IFavoritosRepository repository)
        { 
            _repository = repository;
        }
        public async Task<ResponseDto<bool?>> AgregarFavorito(FavoritosRequestDto favorito)
        {
            ResponseDto<bool?> response = await _repository.InsertarFavorito(favorito);
            return response;
        }

        public async Task<ResponseDto<List<FavoritosResponseDto>>> ObtenerFavoritos(string idUsuario)
        {
            ResponseDto<List<FavoritosResponseDto>> response = await _repository.SeleccionarFavoritos(idUsuario);
            return response;
        }

        public async Task<ResponseDto<bool?>> BorrarFavorito(string idUsuario, int idRecipe)
        {
            ResponseDto<bool?> response = await _repository.EliminarFavorito(idUsuario, idRecipe);
            return response;
        }

    }
}
