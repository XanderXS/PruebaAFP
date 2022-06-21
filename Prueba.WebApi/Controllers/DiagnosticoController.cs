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
    public class DiagnosticoController : Controller
    {
        private readonly IDiagnosticoRepository _diagnostico;

        public DiagnosticoController(IDiagnosticoRepository diagnostico)
        {
            _diagnostico = diagnostico;
        }

        [HttpPost]
        public async Task<ActionResult> createDiagnostico([FromBody] Diagnostico diagnostico)
        {
            try
            {
                return Ok(await _diagnostico.createDiagnostico(diagnostico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> listaDiagnostico()
        {
            try
            {
                return Ok(await _diagnostico.getDiagnostico());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public bool deleteDiagnostico(int Id)
        {
            try
            {
                return _diagnostico.deleteDiagnostico(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
