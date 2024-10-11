using Doctor_Appointment.Dtos.Appointment;
using Doctor_Appointment.Exceptions;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repositories;
using Doctor_Appointment.Service.Abstract;

namespace Doctor_Appointment.Service
{
    public class AppointmentService : IAppointmentService

    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Policlinic> _policlinicRepository;

        public AppointmentService(
            IRepository<Appointment> appointmentRepository,
            IRepository<Doctor> doctorRepository,
            IRepository<Patient> patientRepository,
            IRepository<Policlinic> policlinicRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _policlinicRepository = policlinicRepository;
        }
        public async Task<int> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            var policlinic = await _policlinicRepository.FindByIdAsync(createAppointmentDto.PoliclinicId);
            if (policlinic == null)

            {
                throw new KeyNotFoundException("Policlinic not found!");
            }

            var doctor = await _doctorRepository.FindByIdAsync(createAppointmentDto.DoctorId);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found!");
            }

            var patient = await _patientRepository.FindByIdAsync(createAppointmentDto.PatientId);
            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found!");
            }
            Console.WriteLine(createAppointmentDto.Date);
            var appointment = new Appointment
            {
                Date = createAppointmentDto.Date,
                Policlinic = policlinic,
                Doctor = doctor,
                Patient = patient
            };

            await _appointmentRepository.AddAsync(appointment);

            return appointment.Id;
        }

        public async Task<IEnumerable<Appointment>> FindAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment> FindOneAsync(int id)
        {
            var appointment = await _appointmentRepository.FindByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found!");
            }

            return appointment;

        }

        public async Task RemoveAsync(int id)
        {
            var appointment = await _appointmentRepository.FindByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found!");
            }

            await _appointmentRepository.RemoveAsync(appointment);
        }

        public async Task<int> UpdateAsync(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _appointmentRepository.FindByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found!");
            }

            var policlinic = await _policlinicRepository.FindByIdAsync(updateAppointmentDto.PoliclinicId);
            if (policlinic == null)
            {
                throw new KeyNotFoundException("Policlinic not found!");
            }

            var doctor = await _doctorRepository.FindByIdAsync(updateAppointmentDto.DoctorId);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found!");
            }

            var patient = await _patientRepository.FindByIdAsync(updateAppointmentDto.PatientId);
            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found!");
            }

            appointment.Doctor = doctor;
            appointment.Patient = patient;
            appointment.Policlinic = policlinic;

            await _appointmentRepository.UpdateAsync(appointment);

            return appointment.Id;
        }
    }
}