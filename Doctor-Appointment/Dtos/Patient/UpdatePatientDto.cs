namespace Doctor_Appointment.Dtos.Patient
{
    public class UpdatePatientDto : CreatePatientDto
    {
        public new string Name { get; set; }
        public new string LastName { get; set; }
        public new long? TcNO { get; set; } // Nullable long
    }

}

