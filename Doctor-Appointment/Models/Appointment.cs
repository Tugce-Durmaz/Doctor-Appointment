using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System;


namespace Doctor_Appointment.Models
{

        public class Appointment
        {
            [Key]
            public int Id { get; set; }

            [Column(TypeName = "timestamp")]
            public DateTime Date { get; set; }

            // Many-to-One relationship with Patient
            public int PatientId { get; set; }
            [ForeignKey("PatientId")]
            public virtual Patient Patient { get; set; }

            // Many-to-One relationship with Doctor
            public int DoctorId { get; set; }
            [ForeignKey("DoctorId")]
            public virtual Doctor Doctor { get; set; }

            // Many-to-One relationship with Policlinic
            public int PoliclinicId { get; set; }
            [ForeignKey("PoliclinicId")]
            public virtual Policlinic Policlinic { get; set; }
        }
    }


