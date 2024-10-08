using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Models
{
    //    public class Patient
    //    {

    //        [Key]
    //        public int Id { get; set; }

    //        [Column]
    //        public string Name { get; set; }

    //        [Column]
    //        public string LastName { get; set; }

    //        [Column]
    //        public long TcNO { get; set; } // tcNO, long olarak tanımlandı çünkü genellikle TC kimlik numaraları büyük sayılar.

    //        // Many-to-Many relationship with Policlinic
    //        public virtual ICollection<Policlinic> Policlinics { get; set; }

    //        // One-to-Many relationship with Appointment
    //        public virtual ICollection<Appointment> Appointments { get; set; }

    //        public Patient()
    //        {
    //            Policlinics = new HashSet<Policlinic>();
    //            Appointments = new HashSet<Appointment>();
    //        }
    //}
    //}

    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [Column]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Column]
        public string LastName { get; set; }

        [Required(ErrorMessage = "TC Kimlik No alanı gereklidir.")]
        [Range(10000000000, 99999999999, ErrorMessage = "TC Kimlik No 10 haneli bir sayı olmalıdır.")]
        [Column]
        public long TcNO { get; set; }

        public virtual ICollection<Policlinic> Policlinics { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Policlinics = new HashSet<Policlinic>();
            Appointments = new HashSet<Appointment>();
        }
    }
}

