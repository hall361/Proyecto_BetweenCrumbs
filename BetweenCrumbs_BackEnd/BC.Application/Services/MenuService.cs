using BC.Application.Interfaces;
using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using BC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Models.Dtos.Menu;

namespace BC.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repo;
        public MenuService(IMenuRepository repo)
        {
            _repo = repo;
        }
        public async Task<ResponseDto<List<MenuResponseDto>>> ObtenerMenuPorUsuario(string IdUsuario)
        {
            ResponseDto<List<MenuResponseDto>> response = await _repo.SeleccionarMenuPorUsuario(IdUsuario);
            return response;
        }
    }
}
