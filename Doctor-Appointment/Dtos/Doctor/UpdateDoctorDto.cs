namespace Doctor_Appointment.Dtos.Doctor
{

    public class UpdateDoctorDto : CreateDoctorDto
    {
        public new string Name { get; set; }
        public new string LastName { get; set; }
        //public new string Branch { get; set; }
    }

}

