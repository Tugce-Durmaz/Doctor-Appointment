using Doctor_Appointment.Dtos.Appointment;
using Doctor_Appointment.Models;
using Doctor_Appointment.Service;
using Doctor_Appointment.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Doctor_Appointment.Controllers
{
    
    [ApiController]
    [Route("appointments")]
    public class AppointmentController : ControllerBase
    {

            private readonly IAppointmentService _appointmentService;

            public AppointmentController(IAppointmentService appointmentService)
            {
                _appointmentService = appointmentService;
            }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Hataları yanıt olarak döndür
            }

            try
            {
                var id = await _appointmentService.CreateAsync(createAppointmentDto);
                return CreatedAtAction(nameof(FindOne), new { id }, new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return StatusCode(500, "Bir hata oluştu.");
            }
        }

        [HttpGet]
            public async Task<ActionResult<IEnumerable<Appointment>>> FindAll()
            {
                var appointments = await _appointmentService.FindAllAsync();
                return Ok(appointments);
            }

        [HttpGet("{id}")]
            public async Task<ActionResult<Appointment>> FindOne(int id)
            {
                var appointment = await _appointmentService.FindOneAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(appointment);
            }

            [HttpPatch("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
            {
                var updatedId = await _appointmentService.UpdateAsync(id, updateAppointmentDto);
                if (updatedId == 0)
                {
                    return NotFound();
                }
                return Ok(new { id = updatedId });
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove(int id)
            {
                await _appointmentService.RemoveAsync(id);
                return NoContent();
            }
        }
    }

