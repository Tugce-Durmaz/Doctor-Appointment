using Microsoft.AspNetCore.Mvc;

namespace Doctor_Appointment.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        public IActionResult Menu()
        {
            
            return View("Menu");
        }

        public IActionResult PatientRegister()
        {
            return View("PatientRegister");
        }
        public IActionResult PatientList()
        {
            return View("PatientList");
        }
        public IActionResult DoctorList()
        {
            return View("DoctorList"); 
        }
        public IActionResult PoliclinicList()
        {
            return View("PoliclinicList");
        }
        public IActionResult AppointmentList()
        {
            return View("AppointmentList"); 
        }


    }
}
