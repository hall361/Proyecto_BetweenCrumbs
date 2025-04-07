using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Models.Dtos.Usuario
{
    public class UsuarioRequestDto
    {
        public required string IdUsuario { get; set; }
        public required string NombreUsuario { get; set; }
        public required string CorreoElectronico { get; set; }
        public required string Contrasena { get; set; }
    }
}
