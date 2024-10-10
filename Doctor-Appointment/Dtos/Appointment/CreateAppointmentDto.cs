using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Appointment
{
    public class CreateAppointmentDto
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int PatientId { get; set; }


        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PoliclinicId { get; set; }
    }



}

