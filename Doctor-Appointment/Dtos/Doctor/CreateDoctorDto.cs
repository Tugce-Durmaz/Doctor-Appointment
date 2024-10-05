using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Doctor
{
    public class CreateDoctorDto
    {
        [Required]
        [StringLength(100)] // Max uzunluk isteğe bağlı
        public string Name { get; set; }

        [Required]
        [StringLength(100)] // Max uzunluk isteğe bağlı
        public string LastName { get; set; }

        //[Required]
        //[StringLength(100)]// Max uzunluk isteğe bağlı
        //public string Branch { get; set; }
    }




}

