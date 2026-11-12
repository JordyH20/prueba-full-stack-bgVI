using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_JORDY_HURTADO.Dtos.Request;

namespace WebAPI_JORDY_HURTADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosControllers : ControllerBase
    {
        private readonly Services.VuelosService _vuelosService;
        public VuelosControllers(Services.VuelosService vuelosService)
        {
            _vuelosService = vuelosService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateVuelo([FromBody] VuelosRequest dto)
        {
            var vuelo = await _vuelosService.CreateVueloAsync(dto);
            return CreatedAtAction
                (nameof(GetVueloById),
                new { vuelo },
                new { mensaje = "Vuelo creado correctamente", vueloId = vuelo });
        }

        [HttpGet]
        public async Task<IActionResult> GetVuelos()
        {
            var vuelos = await _vuelosService.GetVuelosAsync();
            return Ok(vuelos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVueloById(int id)
        {
            var vuelo = await _vuelosService.GetVueloByIdAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }
            return Ok(vuelo);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVuelos (int id, [FromBody] VuelosRequest dto)
        {
            var vuelo = await _vuelosService.GetVueloByIdAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            await _vuelosService.UpdateVueloAsync(id, dto);
            return NoContent();
        }
    }
}
