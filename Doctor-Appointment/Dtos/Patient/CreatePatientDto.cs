using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Patient
{
    public class CreatePatientDto
    {

        [Required]
        [StringLength(100)] 
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Range(10000000000, 99999999999)] 
        public long TcNO { get; set; } 
    }

}

