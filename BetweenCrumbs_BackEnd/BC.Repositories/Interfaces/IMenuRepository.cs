using BC.Models.Dtos.Menu;
using BC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task<ResponseDto<List<MenuResponseDto>>> SeleccionarMenuPorUsuario(string IdUsuario);
    }
}
