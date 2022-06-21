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
    public class TipoDoctorController : Controller
    {
        private readonly ITipoDoctorRepository _tipo;

        public TipoDoctorController(ITipoDoctorRepository tipo)
        {
            _tipo = tipo;
        }

        [HttpPost]
        public async Task<ActionResult> createTipoDoctor([FromBody] TipoDotor tipoDotor)
        {
            try
            {
                return Ok(await _tipo.createTipoDoctor(tipoDotor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> listaTipoDoctores()
        {
            try
            {
                return Ok(await _tipo.getTiposDoctor());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public bool deleteTipoDoctor(int Id)
        {
            try
            {
                return _tipo.deleteTipoDoctor(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
