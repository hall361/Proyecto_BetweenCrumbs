using BC.Models.Dtos.Usuario;
using BC.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BC.Models.Dtos.Menu;
using System.Collections.Generic;
using BC.Application.Interfaces;
using BC.Application.Services;

namespace BetweenCrumbsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet("ObtenerMenuPorUsuario")]
        public async Task<ResponseDto<List<MenuResponseDto>>> ObtenerMenuPorUsuario([FromQuery] string IdUsuario)
        {
            ResponseDto<List<MenuResponseDto>> response = await _service.ObtenerMenuPorUsuario(IdUsuario);
            return response;
        }
    }
}
