using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Doctor
{
    public class CreateDoctorDto
    {
        

            [Required]
            [StringLength(100)] 
            public string Name { get; set; }

            [Required]
            [StringLength(100)] 
            public string LastName { get; set; }

           
        }
    }

