namespace Doctor_Appointment.Dtos.Appointment
{
        public class UpdateAppointmentDto : CreateAppointmentDto
    {
        public new DateTime? Date { get; set; }
        public new int PatientId { get; set; }

        public new int DoctorId { get; set; }
        public new int PoliclinicId { get; set; }
    }

}

