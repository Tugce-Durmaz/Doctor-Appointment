using Doctor_Appointment.Dtos.Doctor;
using Doctor_Appointment.Exceptions;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repositories;
using Doctor_Appointment.Service.Abstract;

namespace Doctor_Appointment.Service
{
    public class DoctorService : IDoctorService
    {

        private readonly IRepository<Doctor> _doctorRepository;

        public DoctorService(IRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<int> CreateAsync(CreateDoctorDto createDoctorDto)
        {
            var doctor = new Doctor
            {
                Name = createDoctorDto.Name,
                LastName = createDoctorDto.LastName
            };

            await _doctorRepository.AddAsync(doctor);
            return doctor.Id;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor> FindOneAsync(int id)
        {
            var doctor = await _doctorRepository.FindByIdAsync(id);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found!");
            }

            return doctor;
        }

        public async Task RemoveAsync(int id)
        {
            var doctor = await _doctorRepository.FindByIdAsync(id);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found!");
            }

            await _doctorRepository.RemoveAsync(doctor);
        }

        public async Task<int> UpdateAsync(int id, UpdateDoctorDto updateDoctorDto)
        {
            var doctor = await _doctorRepository.FindByIdAsync(id);
            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found!");
            }

            doctor.Name = updateDoctorDto.Name;
            doctor.LastName = updateDoctorDto.LastName;

            await _doctorRepository.UpdateAsync(doctor);
            return doctor.Id;
        }
    }
}
