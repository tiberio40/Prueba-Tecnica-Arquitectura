using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Model;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ITblInvUbicacionesNService _tblInvUbicacionesNService;

        public ReportController(ITblInvUbicacionesNService tblInvUbicacionesNService)
        {
            _tblInvUbicacionesNService = tblInvUbicacionesNService;
        }

        [HttpPost]
        public async Task<IActionResult> GetStatisticsBasic(SearchModel values) {
            var result = new ReportDTO();
            result.Netavailability = await _tblInvUbicacionesNService.GetNetavailability(values);
            result.TotalCommittedInventory = await _tblInvUbicacionesNService.GetTotalCommittedInventory(values);
            result.UnitsByLocation = await _tblInvUbicacionesNService.GetUnitsByLocation(values);

            return Ok(result);
        }
    }
}
