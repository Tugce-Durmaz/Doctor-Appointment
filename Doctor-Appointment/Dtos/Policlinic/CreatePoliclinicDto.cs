using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Policlinic
{
    public class CreatePoliclinicDto
    {

        [Required]
        [StringLength(100)] 
        public string Name { get; set; }
    }

}

