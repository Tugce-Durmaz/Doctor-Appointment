using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Policlinic
{
    public class CreatePoliclinicDto
    {

        [Required]
        [StringLength(100)] // İsteğe bağlı: Maksimum uzunluğu tanımlamak için
        public string Name { get; set; }
    }

}

