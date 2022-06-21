using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Prueba.Modelo.Interface;
using System;
using Prueba.Modelo.Model;

namespace Prueba.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private readonly ICitaRepository _citaRepository;

        public CitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPost]
        public async Task<ActionResult> createCita([FromBody] Citum cita)
        {
            try
            {
                return Ok(await _citaRepository.createCita(cita));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> listaCita()
        {
            try
            {
                return Ok(await _citaRepository.getCitas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public bool deleteCita(int Id)
        {
            try
            {
                return _citaRepository.deleteCita(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
