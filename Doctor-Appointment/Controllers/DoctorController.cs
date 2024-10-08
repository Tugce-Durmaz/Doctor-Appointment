using Doctor_Appointment.Dtos.Doctor;
using Doctor_Appointment.Dtos.Patient;
using Doctor_Appointment.Models;
using Doctor_Appointment.Service;
using Doctor_Appointment.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doctor_Appointment.Controllers
{
 
        [ApiController]
        [Route("/doctors")]
        public class DoctorController : ControllerBase
        {
            private readonly IDoctorService _doctorService;

            public DoctorController(IDoctorService doctorService)
            {
                _doctorService = doctorService;
            }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto createDoctorDto)
        {
         

            var id = await _doctorService.CreateAsync(createDoctorDto);
            // Kayıt başarılı ise
            return CreatedAtAction(nameof(FindOne), new { id }, new { id });
        }


        [HttpGet]
            public async Task<ActionResult<IEnumerable<Doctor>>> GetAllAsync()
            {
                var doctors = await _doctorService.GetAllAsync();
                return Ok(doctors);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Doctor>> FindOne(int id)
            {
                var doctor = await _doctorService.FindOneAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }

            [HttpPatch("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto updateDoctorDto)
            {
                var updatedId = await _doctorService.UpdateAsync(id, updateDoctorDto);
                if (updatedId == 0)
                {
                    return NotFound();
                }
                return Ok(new { id = updatedId });
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove( int id)
            {
                await _doctorService.RemoveAsync(id);
                return NoContent();
            }
        }

    }

