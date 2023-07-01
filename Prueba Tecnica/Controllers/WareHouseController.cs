using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly ITblInvUbicacionesNService _tblInvUbicacionesNService;

        public WareHouseController(ITblInvUbicacionesNService tblInvUbicacionesNService) {
            _tblInvUbicacionesNService = tblInvUbicacionesNService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(SearchModel value)
        {
            return Ok( await _tblInvUbicacionesNService.GetAllWareHouses());
        }
    }
}
