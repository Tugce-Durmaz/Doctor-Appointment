using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Dtos.Patient
{
    public class CreatePatientDto
    {

        [Required]
        [StringLength(100)] // İsteğe bağlı: Maksimum uzunluğu tanımlamak için
        public string Name { get; set; }

        [Required]
        [StringLength(100)] // İsteğe bağlı: Maksimum uzunluğu tanımlamak için
        public string LastName { get; set; }

        [Required]
        [Range(10000000000, 99999999999)] // TC Kimlik numarası için aralık
        public long TcNO { get; set; } // long, TC kimlik numarası için daha büyük bir değer aralığı sağlar
    }

}

