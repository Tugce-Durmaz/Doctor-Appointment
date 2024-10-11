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
        [Route("patients")]
        public class PatientController : ControllerBase
        {
            private readonly IPatientService _patientService;

            public PatientController(IPatientService patientService)
            {
                _patientService = patientService;
            }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto createPatientDto)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            
            Console.WriteLine(createPatientDto.Name);
            Console.WriteLine(createPatientDto.LastName);
            Console.WriteLine(createPatientDto.TcNO);

            var id = await _patientService.CreateAsync(createPatientDto);
            if (id <= 0) 
            {
                return StatusCode(500, "Kayıt işlemi sırasında bir hata oluştu.");
            }

            return CreatedAtAction(nameof(FindOne), new { id }, new { id });
        }

        [HttpGet]
            public async Task<ActionResult<IEnumerable<Patient>>> FindAll()
            {
                var patients = await _patientService.FindAllAsync();
                return Ok(patients);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Patient>> FindOne(int id)
            {
                var patient = await _patientService.FindOneAsync(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }

            [HttpPatch("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdatePatientDto updatePatientDto)
            {
                var updatedId = await _patientService.UpdateAsync(id, updatePatientDto);
                if (updatedId == 0)
                {
                    return NotFound();
                }
                return Ok(new { id = updatedId });
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove(int id)
            {
                await _patientService.RemoveAsync(id);
                return NoContent();
            }
        }
    }
