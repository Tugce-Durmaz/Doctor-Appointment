using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Doctor_Appointment.Models
{
        public class Patient
        {
      
            [Key]
            public int Id { get; set; }

            [Column]
            public string Name { get; set; }

            [Column]
            public string LastName { get; set; }

            [Column]
            public long TcNO { get; set; } // tcNO, long olarak tanımlandı çünkü genellikle TC kimlik numaraları büyük sayılar.

            // Many-to-Many relationship with Policlinic
            public virtual ICollection<Policlinic> Policlinics { get; set; }

            // One-to-Many relationship with Appointment
            public virtual ICollection<Appointment> Appointments { get; set; }

            public Patient()
            {
                Policlinics = new HashSet<Policlinic>();
                Appointments = new HashSet<Appointment>();
            }
    }
    }

