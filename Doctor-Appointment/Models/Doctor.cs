using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Doctor_Appointment.Models
{        public class Doctor
        {
            [Key]
            public int Id { get; set; }

            [Column]
            public string Name { get; set; }

            [Column]
            public string LastName { get; set; }

           

      

        // One-to-Many relationship with Appointment
        public virtual ICollection<Appointment> Appointments { get; set; }

            // Many-to-One relationship with Policlinic
            public int PoliclinicId { get; set; }
            [ForeignKey("PoliclinicId")]
            public virtual Policlinic Policlinic { get; set; }
            
        public Doctor()
            {
                Appointments = new HashSet<Appointment>();
                
        }

    }
    }


