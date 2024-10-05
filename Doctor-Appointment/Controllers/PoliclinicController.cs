using Doctor_Appointment.Dtos.Policlinic;
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
        [Route("policlinics")]
        public class PoliclinicController : ControllerBase
        {
            private readonly IPoliclinicService _policlinicService;

            public PoliclinicController(IPoliclinicService policlinicService)
            {
                _policlinicService = policlinicService;
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreatePoliclinicDto createPoliclinicDto)
            {
                var id = await _policlinicService.CreateAsync(createPoliclinicDto);
                return CreatedAtAction(nameof(FindOne), new { id }, new { id });
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Policlinic>>> FindAll()
            {
                var policlinics = await _policlinicService.FindAllAsync();
            return Ok(policlinics);
        }

       


        [HttpGet("{id}")]
            public async Task<ActionResult<Policlinic>> FindOne(int id)
            {
                var policlinic = await _policlinicService.FindOneAsync(id);
                if (policlinic == null)
                {
                    return NotFound();
                }
                return Ok(policlinic);
            }

            [HttpPatch("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] UpdatePoliclinicDto updatePoliclinicDto)
            {
                var updatedId = await _policlinicService.UpdateAsync(id, updatePoliclinicDto);
                if (updatedId == 0)
                {
                    return NotFound();
                }
                return Ok(new { id = updatedId });
            }

            [HttpPatch("{id}/doctors/{doctorId}")]
            public async Task<IActionResult> AddDoctor(int id, int doctorId)
            {
                var updatedId = await _policlinicService.AddDoctorAsync(id, doctorId);
                return Ok(new { id = updatedId });
            }

            [HttpDelete("{id}/doctors/{doctorId}")]
            public async Task<IActionResult> RemoveDoctor(int id, int doctorId)
            {
                await _policlinicService.RemoveDoctorAsync(id, doctorId);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove(int id)
            {
                await _policlinicService.RemoveAsync(id);
                return NoContent();
            }
        }
    }
