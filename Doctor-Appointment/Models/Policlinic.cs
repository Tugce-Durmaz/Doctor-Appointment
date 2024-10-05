using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace Doctor_Appointment.Models
{
        public class Policlinic
        {
            [Key]
            public int Id { get; set; }

            [Column]
            public string Name { get; set; }

            // One-to-Many relationship with Doctor
            public virtual ICollection<Doctor> Doctors { get; set; }

            // Many-to-Many relationship with Patient
            public virtual ICollection<Patient> Patients { get; set; }

            // One-to-Many relationship with Appointment
            public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        public Policlinic()
            {
                Doctors = new HashSet<Doctor>();
                Patients = new HashSet<Patient>();
                Appointments = new HashSet<Appointment>();
            }

        
    }
    }


