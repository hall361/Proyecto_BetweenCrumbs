using BC.Models.Dtos.Menu;
using BC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Application.Interfaces
{
    public interface IMenuService
    {
        Task<ResponseDto<List<MenuResponseDto>>> ObtenerMenuPorUsuario(string IdUsuario);
    }
}
