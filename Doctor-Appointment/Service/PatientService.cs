using Doctor_Appointment.Dtos.Patient;
using Doctor_Appointment.Exceptions;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repositories;
using Doctor_Appointment.Service.Abstract;

namespace Doctor_Appointment.Service
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<int> CreateAsync(CreatePatientDto createPatientDto)
        {
            var patient = new Patient
            {
                Name = createPatientDto.Name,
                LastName = createPatientDto.LastName,
                TcNO = createPatientDto.TcNO
            };

            await _patientRepository.CreateAsync(patient);
            return patient.Id;
        }

        public async Task<IEnumerable<Patient>> FindAllAsync()
        {
            return await _patientRepository.GetAllAsync(includeProperties: new[] { "Policlinics" });
        }

        public async Task<Patient> FindOneAsync(int id)
        {
            var patient = await _patientRepository.FindByIdAsync(id, includeProperties: new[] { "Policlinics" });
            if (patient == null)
            {
                throw new NotFoundException("Patient not found!");
            }

            return patient;
        }

        public async Task<int> UpdateAsync(int id, UpdatePatientDto updatePatientDto)
        {
            var patient = await _patientRepository.FindByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException("Patient not found!");
            }

            patient.Name = updatePatientDto.Name;
            patient.LastName = updatePatientDto.LastName;
            patient.TcNO = (long)updatePatientDto.TcNO;

            await _patientRepository.UpdateAsync(patient);
            return patient.Id;
        }

        public async Task RemoveAsync(int id)
        {
            var patient = await _patientRepository.FindByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException("Patient not found!");
            }

            await _patientRepository.RemoveAsync(patient);
        }
    }
}
