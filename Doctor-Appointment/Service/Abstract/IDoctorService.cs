using Doctor_Appointment.Dtos.Doctor;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Service.Abstract
{
    public interface IDoctorService
    {
            Task<int> CreateAsync(CreateDoctorDto createDoctorDto);
            Task<IEnumerable<Doctor>> GetAllAsync();
            Task<Doctor> FindOneAsync(int id);
            Task<int> UpdateAsync(int id, UpdateDoctorDto updateDoctorDto);
            Task RemoveAsync(int id);
        

    }
    }
