using Microsoft.AspNetCore.Mvc;

namespace Doctor_Appointment.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        public IActionResult Menu()
        {
            // Burada menüyle ilgili işlemler yapılabilir.
            return View("Menu"); // 'Views/Menu/Menu.cshtml' dosyasını döner.
        }

        public IActionResult PatientRegister()
        {
            return View("PatientRegister"); // PatientRegister.cshtml sayfasını göster
        }
        public IActionResult PatientList()
        {
            return View("PatientList"); // PatientRegister.cshtml sayfasını göster
        }
        public IActionResult DoctorList()
        {
            return View("DoctorList"); // PatientRegister.cshtml sayfasını göster
        }
        public IActionResult PoliclinicList()
        {
            return View("PoliclinicList"); // PatientRegister.cshtml sayfasını göster
        }
        public IActionResult AppointmentList()
        {
            return View("AppointmentList"); // PatientRegister.cshtml sayfasını göster
        }


    }
}
