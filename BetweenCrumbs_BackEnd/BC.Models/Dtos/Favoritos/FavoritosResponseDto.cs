using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Models.Dtos.Favoritos
{
    public class FavoritosResponseDto
    {
        public int IdFavorito { get; set; }
        public string? IdRecipe { get; set; }
        public string? NombreRecipe { get; set; }
        public string? IdUsuario { get; set; }
    }
}
