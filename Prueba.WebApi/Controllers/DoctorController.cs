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
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctor;

        public DoctorController(IDoctorRepository doctor)
        {
            _doctor = doctor;
        }

        [HttpPost]
        public async Task<ActionResult> createDoctor([FromBody] Doctor doctor)
        {
            try
            {
                return Ok(await _doctor.createDoctor(doctor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> updateDoctor([FromBody] Doctor doctor)
        {
            try
            {
                return Ok(await _doctor.updateDoctor(doctor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> listaDoctores()
        {
            try
            {
                return Ok(await _doctor.GetDoctores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public bool deleteDoctor(int Id)
        {
            try
            {
                return _doctor.deleteDoctor(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
