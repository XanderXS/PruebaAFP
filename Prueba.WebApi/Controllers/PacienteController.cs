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
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _paciente;

        public PacienteController(IPacienteRepository paciente)
        {
            _paciente = paciente;
        }

        [HttpPost]
        public async Task<ActionResult> createPaciente([FromBody] Paciente paciente)
        {
            try
            {
                return Ok(await _paciente.createPaciente(paciente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updatePaciente([FromBody] Paciente paciente)
        {
            try
            {
                return Ok(await _paciente.updatePaciente(paciente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> listaPacientes()
        {
            try
            {
                return Ok(await _paciente.GetPacientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public bool deletePaciente(int Id)
        {
            try
            {
                return  _paciente.deletePaciente(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //[HttpGet]
        //[Route("{Id}")]
        //public async Task<IActionResult> getPaciente(int Id)
        //{
        //    try
        //    {
        //        return Ok(await _paciente.GetPacienteById(Id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}
